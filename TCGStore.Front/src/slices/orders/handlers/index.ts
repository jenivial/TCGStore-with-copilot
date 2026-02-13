import { Order } from '../../domain/types';
import { OrderRepository } from '../../persistence/repository';

export const createOrder = async (orderData: Order) => {
    const orderRepository = new OrderRepository();
    const newOrder = await orderRepository.create(orderData);
    return newOrder;
};

export const getOrderById = async (orderId: string) => {
    const orderRepository = new OrderRepository();
    const order = await orderRepository.findById(orderId);
    return order;
};

export const updateOrder = async (orderId: string, orderData: Partial<Order>) => {
    const orderRepository = new OrderRepository();
    const updatedOrder = await orderRepository.update(orderId, orderData);
    return updatedOrder;
};

export const deleteOrder = async (orderId: string) => {
    const orderRepository = new OrderRepository();
    await orderRepository.delete(orderId);
};