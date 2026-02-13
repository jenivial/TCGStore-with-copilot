import { Card } from '../domain/types';
import { CardsRepository } from '../persistence/repository';

export class CardsHandler {
    private repository: CardsRepository;

    constructor() {
        this.repository = new CardsRepository();
    }

    async getAllCards(): Promise<Card[]> {
        return await this.repository.getAll();
    }

    async getCardById(id: string): Promise<Card | null> {
        return await this.repository.getById(id);
    }
}
