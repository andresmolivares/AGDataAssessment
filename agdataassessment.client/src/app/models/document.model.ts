export class DocumentModel {
  constructor(public name: string, public address: string) {
    if (!this.isDataValid()) throw new Error('Name is required.');
  }

  id: string | undefined;

  isDataValid(): boolean {
    return !!this.name && this.name.length > 0;
  }
}
