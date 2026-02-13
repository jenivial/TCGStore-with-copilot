export interface Order {
    id: string;
    customerId: string;
    items: OrderItem[];
    totalAmount: number;
    status: OrderStatus;
    createdAt: Date;
    updatedAt: Date;
}

export interface OrderItem {
    productId: string;
    quantity: number;
    price: number;
}

export enum OrderStatus {
    Pending = 'Pending',
    Completed = 'Completed',
    Canceled = 'Canceled',
}