import { CatalogItem } from '../domain/types';
import { CatalogRepository } from '../persistence/repository';

export class CatalogHandler {
    private repository: CatalogRepository;

    constructor() {
        this.repository = new CatalogRepository();
    }

    async getAllItems(): Promise<CatalogItem[]> {
        return await this.repository.getAll();
    }

    async getItemById(id: string): Promise<CatalogItem | null> {
        return await this.repository.getById(id);
    }

    async createItem(item: CatalogItem): Promise<CatalogItem> {
        return await this.repository.create(item);
    }

    async updateItem(id: string, item: CatalogItem): Promise<CatalogItem | null> {
        return await this.repository.update(id, item);
    }

    async deleteItem(id: string): Promise<boolean> {
        return await this.repository.delete(id);
    }
}