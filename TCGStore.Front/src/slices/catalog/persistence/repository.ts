import { CatalogItem } from '../domain/types';
import { db } from '../../../lib/db';

export class CatalogRepository {
    async getAllItems(): Promise<CatalogItem[]> {
        const items = await db.catalog.findMany();
        return items;
    }

    async getItemById(id: string): Promise<CatalogItem | null> {
        const item = await db.catalog.findUnique({
            where: { id },
        });
        return item;
    }

    async createItem(item: CatalogItem): Promise<CatalogItem> {
        const newItem = await db.catalog.create({
            data: item,
        });
        return newItem;
    }

    async updateItem(id: string, item: Partial<CatalogItem>): Promise<CatalogItem | null> {
        const updatedItem = await db.catalog.update({
            where: { id },
            data: item,
        });
        return updatedItem;
    }

    async deleteItem(id: string): Promise<CatalogItem | null> {
        const deletedItem = await db.catalog.delete({
            where: { id },
        });
        return deletedItem;
    }
}