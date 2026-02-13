export interface Card {
    id: string;
    name: string;
    setName: string;
    setCode?: string | null;
    collectorNumber: number;
    rarity: string;
    price: number;
    imageUrl?: string | null;
    description?: string | null;
    createdAt: string;
    updatedAt: string;
}
