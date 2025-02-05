import { Injectable } from '@angular/core';
import axios from 'axios';
import { DocumentModel } from '../models/document.model';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private apiDocumentUrl = 'http://localhost:5098/api/document';
  private apiDocumentQueryUrl = 'http://localhost:5098/api/document/query';

  constructor() {}

  async addData(data: DocumentModel): Promise<any> {
    try {
      const response = await axios.post(this.apiDocumentUrl, data);
      return response.data;
    } catch (error) {
      console.error('Error adding data:', error);
      throw error;
    }
  }

  async updateData(data: DocumentModel): Promise<any> {
    try {
      const response = await axios.put(this.apiDocumentUrl, data);
      return response.data;
    } catch (error) {
      console.error('Error updating data:', error);
      throw error;
    }
  }

  async deleteData(id: string): Promise<any> {
    try {
      const url = `${this.apiDocumentUrl}/${id}`;
      await axios.delete(url);
    } catch (error) {
      console.error('Error deleting data:', error);
      throw error;
    }
  }

  // Fetch all items from the API
  async getItems(): Promise<any[]> {
    try {
      const response = await axios.get(this.apiDocumentQueryUrl);
      return response.data;
    } catch (error) {
      console.error('Error fetching data:', error);
      throw error;
    }
  }
}
