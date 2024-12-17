import React, { createContext, useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import BusinessPage from './pages/BusinessPage';
import OrderPage from './pages/OrderPage';
import OrderForm from './components/Order/OrderForm';
import OrderList from './components/Order/OrderList';
import OrderDetails from './components/Order/OrderDetails';
import ProductPage from './pages/ProductPage';
import ReservationPage from './pages/ReservationPage';
import UserPage from './pages/UserPage';
import BusinessForm from './components/Business/BusinessForm';
import CategoryPage from './pages/CategoryPage';
import BusinessList from './components/Business/BusinessList';
import BusinessDetails from './components/Business/BusinessDetails';
import { fetchBusinesses } from './api/business';  // Assuming this function is defined

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
  const [reservations, setReservations] = useState({});
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
    businesses,        // Add businesses to context
    setBusinesses,     // Add setBusinesses to context
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
    reservations, 
    setReservations,
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
              <li><Link to="/reservation">Reservations</Link></li>
              <li><Link to="/user">Users</Link></li>
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
            <Route path="/product" element={<ProductPage />} />
            <Route path="/reservation" element={<ReservationPage />} />
            <Route path="/user" element={<UserPage />} />
          </Routes>
        </div>
      </Router>
    </myContext.Provider>
  );
}

export default App;
