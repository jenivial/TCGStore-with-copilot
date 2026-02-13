export interface Product {
    id: string;
    name: string;
    description: string;
    price: number;
    category: string;
}

export interface Catalog {
    products: Product[];
}

export type CreateProductInput = Omit<Product, 'id'>;

export type UpdateProductInput = Partial<Product>;