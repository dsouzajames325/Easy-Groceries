import { Product } from '../models/Product';

let basket: Product[] = JSON.parse(localStorage.getItem('basket') || '[]');

export const addToBasket = (product: Product) => {
  basket.push(product);
  localStorage.setItem('basket', JSON.stringify(basket));
};

export const getBasket = (): Product[] => basket;

export const clearBasket = () => {
  basket = [];
  localStorage.removeItem('basket');
};
