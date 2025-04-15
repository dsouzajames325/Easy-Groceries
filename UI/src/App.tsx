import React from 'react';
import ProductList from './components/ProductList';
import CheckoutPage from './components/CheckoutPage';

const App: React.FC = () => {
  return (
    <div className="container mx-auto p-6">
      <h1 className="text-4xl font-extrabold text-center mb-6 text-indigo-600">EasyGroceries</h1>
      
      <ProductList />

      <CheckoutPage />
    </div>
  );
};

export default App;
