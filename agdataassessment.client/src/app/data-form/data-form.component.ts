import { Component } from '@angular/core';
import { DataService } from '../services/data.service';
import { DataModel } from '../models/data.model';

@Component({
  selector: 'data-form',
  templateUrl: './data-form.component.html',
  styleUrls: ['./data-form.component.css'],
})
export class DataFormComponent {
  name: string = '';
  address: string = '';
  response: any;
  nameError: string = '';

  constructor(private dataService: DataService) {}

  async submitForm(event: Event) {
    event.preventDefault();
    this.nameError = '';

    try {
      const data = new DataModel(this.name, this.address);
      this.response = await this.dataService.submitData(data);
    } catch (error: any) {
      this.nameError = error.response?.data ?? error.message;
    }
  }
}
