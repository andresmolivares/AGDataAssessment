import { Injectable } from '@angular/core';
import axios from 'axios';
import { DataModel } from '../models/data.model';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private apiUrl = 'http://localhost:5098/api/data';

  constructor() {}

  async submitData(data: DataModel): Promise<any> {
    try {
      const response = await axios.post(this.apiUrl, data);
      return response.data;
    } catch (error) {
      console.error('Error submitting data:', error);
      throw error;
    }
  }
}
