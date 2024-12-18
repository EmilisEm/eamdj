import React, { createContext, useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import BusinessPage from './pages/BusinessPage';
import OrderPage from './pages/OrderPage';
import OrderForm from './components/Order/OrderForm';
import OrderList from './components/Order/OrderList';
import OrderDetails from './components/Order/OrderDetails';

import ProductPage from './pages/ProductPage';
import ProductForm from './components/Product/ProductForm';
import ProductList from './components/Product/ProductList';
import ProductDetails from './components/Product/ProductDetails';
import ProductModifiers from './components/Product/ProductModifiers';

import ServiceTimePage from './pages/ServiceTimePage';
import ServiceTimeForm from './components/ServiceTime/ServiceTimeForm';
import ServiceTimeList from './components/ServiceTime/ServiceTimeList';
import ServiceTimeDetails from './components/ServiceTime/ServiceTimeDetails';

import ReservationPage from './pages/ReservationPage';
import UserPage from './pages/UserPage';
import BusinessForm from './components/Business/BusinessForm';
import CategoryPage from './pages/CategoryPage';
import BusinessList from './components/Business/BusinessList';
import BusinessDetails from './components/Business/BusinessDetails';
import TaxPage from './pages/TaxPage';
import { fetchBusinesses } from './api/business';  // Assuming this function is defined
import LoginPage from './pages/LoginPage';

export const myContext = createContext();

function App() {
  const [business, setBusiness] = useState({
    name: '',
    email: '',
    address: '',
  });
  const [businesses, setBusinesses] = useState([]);  // Add state for businesses
  const [currentBusiness, setCurrentBusiness] = useState({});
  const [user, setUser] = useState({});
  const [currentUser, setCurrentUser] = useState({});
  const [orders, setCurrentOrders] = useState({});
  const [currentOrders, setOrders] = useState({});
  const [products, setProducts] = useState({});
  const [currentProducts, setCurrentProducts] = useState({});
  const [categories, setCategories] = useState({});
  const [currentCategories, setCurrentCategories] = useState({});
  const [taxes, setTaxes] = useState({});
  const [currentTaxes, setCurrentTaxes] = useState({});
  const [reservations, setReservations] = useState({});
  const [serviceTimes, setServiceTimes] = useState({});
  const [currentServiceTimes, setCurrentServiceTimes] = useState({});
  const [currentReservations, setCurrentReservations] = useState({});

  // Fetch businesses when the component mounts
    useEffect(() => {
        const getBusinesses = async () => {
            try {
                const fetchedBusinesses = await fetchBusinesses();
                setBusinesses(fetchedBusinesses);
            } catch (error) {
                console.error("Failed to fetch businesses", error);
            }
        };
        getBusinesses();
    }, []);

  

  const value = {
    business, 
    setBusiness, 
    currentBusiness, 
    setCurrentBusiness, 
    businesses,       
    setBusinesses,    
    user, 
    setUser, 
    currentUser, 
    setCurrentUser, 
    orders, 
    setOrders,  
    setCurrentOrders, 
    currentOrders,
    products,
    setProducts,
    currentProducts, 
    setCurrentProducts,
    categories,
    setCategories,
    currentCategories,
    setCurrentCategories,
    taxes,
    setTaxes,
    setCurrentTaxes,
    currentTaxes,
    reservations, 
    setReservations,
    currentReservations,
    setCurrentReservations,
    serviceTimes,
    setServiceTimes,
    currentReservations,
    setCurrentReservations
  };

  return (
    <myContext.Provider value={value}>
      <Router>
        <div className="App">
          <nav>
            <ul>
              <li><Link to="/">Home</Link></li>
              <li><Link to="/business">Businesses</Link></li>
              <li><Link to="/category">Category</Link></li>
              <li><Link to="/order">Orders</Link></li>
              <li><Link to="/product">Products</Link></li>
              <li><Link to="/service-time">Service Times</Link></li>
              <li><Link to="/reservation">Reservations</Link></li>
              <li><Link to="/user">Users</Link></li>
              <li><Link to="/tax">Taxes</Link></li>
              <li><Link to="/login">Login</Link></li>
            </ul>
          </nav>

          <Routes>
            <Route path="/" element={<h1>Welcome to the Restaurant Management App</h1>} />
            
            <Route path="/business" element={<BusinessPage />}>
              <Route path="create" element={<BusinessForm onSuccess={() => {}} />} />
              <Route path="businesslist" element={<BusinessList/>} />
              <Route path=":id" element={<BusinessDetails />} />
              <Route path="update/:id" element={<BusinessDetails isUpdate={true} />} />
              <Route path="delete/:id" element={<BusinessDetails isDelete={true} />} />
            </Route>

            <Route path="/category/*" element={<CategoryPage />} />

            <Route path="/order" element={<OrderPage />}>
              <Route path="create" element={<OrderForm onSuccess={() => {}} />} />
              <Route path="orderlist" element={<OrderList />} />
              <Route path=":id" element={<OrderDetails />} />
              <Route path="update/:id" element={<OrderDetails isUpdate={true} />} />
              <Route path="delete/:id" element={<OrderDetails isDelete={true} />} />
            </Route>

            <Route path="/product/*" element={<ProductPage />}>
                <Route path="create" element={<ProductForm onSuccess={() => { }} businessId={currentBusiness.id} />} />
                <Route path="productlist" element={<ProductList categoryId={currentCategories[0]?.id} />} />
                <Route path=":id" element={<ProductDetails />} />
                <Route path=":id/modifiers" element={<ProductModifiers />} />
            </Route>

            <Route path="service-time" element={<ServiceTimePage />}>
                <Route path="service-timelist" element={<ServiceTimeList />} />
                <Route path=":id" element={<ServiceTimeDetails />} />
            </Route>
            <Route path="/reservation" element={<ReservationPage />} />
            <Route path="/user" element={<UserPage />} />
            <Route path="/tax/*" element={<TaxPage />} />
            <Route path="/login" element={<LoginPage />} />
          </Routes>
        </div>
      </Router>
    </myContext.Provider>
  );
}

export default App;