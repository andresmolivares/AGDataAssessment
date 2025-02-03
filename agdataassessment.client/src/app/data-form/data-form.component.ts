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
  nameError: string = '';
  itemStates = ItemStateEnum;

  constructor(private dataService: DataService) {}

  ngOnInit() {
    if (this.itemState === ItemStateEnum.Adding) {
      this.data = { name: '', address: '' };
    }
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
      const document = new DocumentModel(this.data.name, this.data.address);
      await this.dataService.addData(document);
      this.closeModal();
    } catch (error: any) {
      this.nameError = error.response?.data ?? error.message;
    }
  }

  async updateDocument() {
    try {
      await this.dataService.updateData(this.data);
      this.closeModal();
    } catch (error: any) {
      this.nameError = 'Name is required';
    }
  }
}
