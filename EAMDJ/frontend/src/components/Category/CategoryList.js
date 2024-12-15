import React, { useEffect, useState } from 'react';
import { fetchCategoriesByBusiness, deleteCategory } from '../../api/category';
import LoadingSpinner from '../Shared/LoadingSpinner';

const CategoryList = ({ businessId }) => {
    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(true);
    
    useEffect(() => {
        const loadCategories = async () => {
        try {
            const data = await fetchCategoriesByBusiness(businessId);
            setCategories(data);
        } catch (error) {
            console.error(error);
        } finally {
            setLoading(false);
        }
        };
    
        loadCategories();
    }, [businessId]);
    
    const handleDelete = async (id) => {
        if (window.confirm('Are you sure you want to delete this category?')) {
        await deleteCategory(id);
        setCategories(categories.filter((category) => category.id !== id));
        }
    };
    
    if (loading) return <LoadingSpinner />;
    
    return (
        <div>
        <h1>Categories</h1>
        <ul>
            {categories.map((category) => (
            <li key={category.id}>
                <p>{category.name}</p>
                <button onClick={() => handleDelete(category.id)}>Delete</button>
            </li>
            ))}
        </ul>
        </div>
    );
};

export default CategoryList;