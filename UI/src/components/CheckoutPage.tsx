import React, { useState } from 'react';
import { getBasket, clearBasket } from '../services/BasketService'
import { Product } from '../models/Product';

const CheckoutPage: React.FC = () => {
  const [hasLoyalty, setHasLoyalty] = useState(false);
  const [shippingAddress, setShippingAddress] = useState('');
  const basket: Product[] = getBasket();

  const calculateTotal = () => {
    const total = basket.reduce((sum, item) => sum + item.price, 0);
    return hasLoyalty ? total * 0.8 : total;
  };

  const handleCheckout = async () => {
    const orderData = {
      productIds: basket.map(item => item.id),
      hasLoyaltyMembership: hasLoyalty,
      shippingAddress,
    };

    try {
      const response = await fetch('https://localhost:7140/api/order/create-order', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(orderData),
      });

      if (!response.ok) {
        throw new Error('Failed to process order');
      }

      const order = await response.json();
      console.log('Order placed successfully:', order);
      clearBasket();
      alert('Order placed successfully!');
    } catch (error) {
      console.error('Error during checkout:', error);
      alert('There was an error processing your order.');
    }
  };

  return (
    <div className="max-w-4xl mx-auto p-6 bg-white shadow-md rounded-lg">
      <h2 className="text-2xl font-bold mb-6">Checkout</h2>
      <label className="block mb-4">
        Shipping Address:
        <input
          type="text"
          className="w-full p-2 mt-2 border border-gray-300 rounded-md"
          value={shippingAddress}
          onChange={e => setShippingAddress(e.target.value)}
          required
        />
      </label>

      <div className="mb-4">
        <label className="flex items-center">
          <input
            type="checkbox"
            checked={hasLoyalty}
            onChange={e => setHasLoyalty(e.target.checked)}
            className="mr-2"
          />
          Apply Loyalty Membership (20% Discount)
        </label>
      </div>

      <div className="mb-4">
        <h3 className="text-lg font-semibold">Order Summary</h3>
        <ul className="list-none p-0">
          {basket.map((product, index) => (
            <li key={index} className="flex justify-between py-2">
              <span>{product.name}</span>
              <span>£{product.price.toFixed(2)}</span>
            </li>
          ))}
        </ul>
        <div className="flex justify-between py-2 mt-4 font-bold">
          <span>Total</span>
          <span>£{calculateTotal().toFixed(2)}</span>
        </div>
      </div>

      <button
        onClick={handleCheckout}
        className="w-full bg-green-500 text-white p-3 rounded-md hover:bg-green-600 transition"
      >
        Place Order
      </button>
    </div>
  );
};

export default CheckoutPage;
