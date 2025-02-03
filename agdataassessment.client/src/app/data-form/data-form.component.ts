import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DataService } from '../services/data.service';
import { ItemStateEnum } from '../data-list/data-list.component';
import { DocumentModel } from '../models/document.model';

@Component({
  selector: 'data-form',
  templateUrl: './data-form.component.html',
  styleUrls: ['./data-form.component.css'],
})
export class DataFormComponent {
  @Input() data: any;
  @Input() itemState: ItemStateEnum = ItemStateEnum.Viewing;
  @Output() close = new EventEmitter<void>();
  name: string = '';
  address: string = '';
  response: any;
  nameError: string = '';

  itemStates = ItemStateEnum;

  constructor(private dataService: DataService) {}

  ngOnInit() {
    this.name = this.data?.name;
    this.address = this.data?.address;
  }

  closeModal() {
    this.close.emit();
  }

  async submitForm(event: Event) {
    event.preventDefault();
    this.nameError = '';

    switch (this.itemState) {
      case ItemStateEnum.Adding:
        await this.addDocument();
        break;
      case ItemStateEnum.Editing:
        await this.updateDocument();
        break;
      default:
        break;
    }
  }

  async addDocument() {
    try {
      const document = new DocumentModel(this.name, this.address);
      this.response = await this.dataService.addData(document);
      this.closeModal();
    } catch (error: any) {
      this.nameError = error.response?.data ?? error.message;
    }
  }

  async updateDocument() {
    try {
      this.data.name = this.name;
      this.data.address = this.address;
      this.response = await this.dataService.updateData(this.data);
      this.closeModal();
    } catch (error: any) {
      this.nameError = error.response?.data ?? error.message;
    }
  }
}
