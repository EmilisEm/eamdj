import React from 'react';
import { Link, Route, Routes } from 'react-router-dom';
import CategoryForm from '../components/Category/CategoryForm';
import CategoryList from '../components/Category/CategoryList';
import CategoryDetails from '../components/Category/CategoryDetails';

function CategoryPage() {
    return (
        <div>
            <h1>Categories</h1>
            <nav>
                <ul>
                    <li><Link to="create">Create Category</Link></li>
                    <li><Link to="categorylist">List All Categories</Link></li>
                </ul>
            </nav>

            <Routes>
                <Route path="create" element={<CategoryForm />} />
                <Route path="categorylist" element={<CategoryList />} />
                <Route path=":id" element={<CategoryDetails />} />
            </Routes>
        </div>
    );
}

export default CategoryPage;
