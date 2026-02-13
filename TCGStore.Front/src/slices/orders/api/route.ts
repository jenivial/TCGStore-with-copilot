import { NextApiRequest, NextApiResponse } from 'next';
import { OrderRepository } from '../persistence/repository';

const orderRepository = new OrderRepository();

export default async function handler(req: NextApiRequest, res: NextApiResponse) {
    switch (req.method) {
        case 'GET':
            const orders = await orderRepository.getAllOrders();
            res.status(200).json(orders);
            break;
        case 'POST':
            const newOrder = await orderRepository.createOrder(req.body);
            res.status(201).json(newOrder);
            break;
        default:
            res.setHeader('Allow', ['GET', 'POST']);
            res.status(405).end(`Method ${req.method} Not Allowed`);
    }
}