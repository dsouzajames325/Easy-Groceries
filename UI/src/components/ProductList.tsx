import React, { useState, useEffect } from 'react';
import { Product } from '../models/Product';
import { addToBasket } from '../services/BasketService'

const ProductList: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch('https://localhost:7140/api/order/get-products') // Assuming the API is running on localhost:5001
      .then(response => response.json())
      .then(data => {
        setProducts(data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Error fetching products:', error);
        setLoading(false);
      });
  }, []);

  if (loading) return <div className="text-center text-lg">Loading products...</div>;

  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
      {products.map(product => (
        <div key={product.id} className="bg-white p-4 shadow-lg rounded-lg hover:shadow-xl transition">
          <h3 className="text-lg font-semibold">{product.name}</h3>
          <p className="text-gray-600 text-sm">{product.description}</p>
          <p className="mt-2 text-xl font-bold">£{product.price.toFixed(2)}</p>
          <button
            onClick={() => addToBasket(product)}
            className="mt-4 w-full bg-blue-500 text-white p-2 rounded-md hover:bg-blue-600 transition"
          >
            Add to Basket
          </button>
        </div>
      ))}
    </div>
  );
};

export default ProductList;
