import React, { useEffect, useState } from 'react';
import { fetchProductsByCategory, deleteProduct } from '../../api/product';
import LoadingSpinner from '../Shared/LoadingSpinner';

const ProductList = ({ categoryId }) => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    
    useEffect(() => {
        const loadProducts = async () => {
        try {
            const data = await fetchProductsByCategory(categoryId);
            setProducts(data);
        } catch (error) {
            console.error(error);
        } finally {
            setLoading(false);
        }
        };
    
        loadProducts();
    }, [categoryId]);

    const handleDelete = async (id) => {
        if (window.confirm('Are you sure you want to delete this product?')) {
        await deleteProduct(id);
        setProducts(products.filter((product) => product.id !== id));
        }
    }

    if (loading) return <LoadingSpinner />;

    return (
        <div>
        <h1>Products</h1>
        <ul>
            {products.map((product) => (
            <li key={product.id}>
                <p>{product.name}</p>
                <button onClick={() => handleDelete(product.id)}>Delete</button>
            </li>
            ))}
        </ul>
        </div>
    );
}

export default ProductList;