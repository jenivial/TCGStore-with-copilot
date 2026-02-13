import { Order } from '../domain/types';
import { db } from '../../../lib/db';

export class OrderRepository {
    async createOrder(order: Order): Promise<Order> {
        const result = await db('orders').insert(order).returning('*');
        return result[0];
    }

    async getOrderById(orderId: string): Promise<Order | null> {
        const result = await db('orders').where({ id: orderId }).first();
        return result || null;
    }

    async updateOrder(orderId: string, orderData: Partial<Order>): Promise<Order | null> {
        const result = await db('orders').where({ id: orderId }).update(orderData).returning('*');
        return result[0] || null;
    }

    async deleteOrder(orderId: string): Promise<boolean> {
        const result = await db('orders').where({ id: orderId }).del();
        return result > 0;
    }

    async getAllOrders(): Promise<Order[]> {
        return await db('orders').select('*');
    }
}