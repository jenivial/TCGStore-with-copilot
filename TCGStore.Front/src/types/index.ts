export type ApiResponse<T> = {
  success: boolean;
  data?: T;
  error?: string;
};

export interface CatalogItem {
  id: string;
  name: string;
  description: string;
  price: number;
}

export interface Order {
  id: string;
  itemId: string;
  quantity: number;
  totalPrice: number;
}

export interface User {
  id: string;
  name: string;
  email: string;
}