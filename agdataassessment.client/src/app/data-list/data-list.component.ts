import { Component } from '@angular/core';
import { DataService } from '../services/data.service';

export enum ItemStateEnum {
  Adding,
  Editing,
  Viewing,
}

@Component({
  selector: 'data-list',
  templateUrl: './data-list.component.html',
  styleUrls: ['./data-list.component.css'],
})
export class DataListComponent {
  modalOpen: boolean = false;
  confirmDelete: boolean = false;
  isLoading: boolean = false;
  dataList: any[] = [];
  selectedItem: any;
  itemState: ItemStateEnum = ItemStateEnum.Viewing;

  itemStates = ItemStateEnum;

  constructor(private dataService: DataService) {}

  ngOnInit() {
    this.loadItems();
  }

  async loadItems() {
    this.isLoading = true;
    try {
      this.dataList = await this.dataService.getItems();
    } catch (error) {
      console.error('Failed to load data:', error);
    } finally {
      this.isLoading = false;
    }
  }

  openModal(item: any = null, isEdit: boolean = false) {
    this.modalOpen = true;
    this.selectedItem = item;
    this.itemState = isEdit
      ? item
        ? ItemStateEnum.Editing
        : ItemStateEnum.Adding
      : ItemStateEnum.Viewing;
  }

  closeModal() {
    this.modalOpen = false;
    this.loadItems();
  }

  openDeleteDialog(item: any) {
    this.selectedItem = item;
    this.confirmDelete = true;
  }

  cancelDelete() {
    this.selectedItem = null;
    this.confirmDelete = false;
  }

  async deleteItem() {
    try {
      this.dataList = await this.dataService.deleteData(this.selectedItem.id);
      this.confirmDelete = false;
      this.loadItems();
    } catch (error) {
      console.error('Failed to delete data:', error);
    }
  }
}
