import React, { useState } from 'react';
import { createProduct } from '../../api/product';
import { useNavigate } from 'react-router-dom';

function ProductForm() {
    const [newProduct, setNewProduct] = useState({
        price: 0,
        name: '',
        description: '',
        categoryId: '',
    });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        try {
            await createProduct(newProduct);
            navigate('/product/productlist');
        } catch (error) {
            setError('Failed to create product');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Create Product</h2>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <form onSubmit={handleSubmit}>
                <label>
                    Name:
                    <input value={newProduct.name} onChange={(e) => setNewProduct({ ...newProduct, name: e.target.value })} />
                </label>
                <label>
                    Price:
                    <input value={newProduct.price} onChange={(e) => setNewProduct({ ...newProduct, price: parseFloat(e.target.value) })} />
                </label>
                <label>
                    Description:
                    <input value={newProduct.description} onChange={(e) => setNewProduct({ ...newProduct, description: e.target.value })} />
                </label>
                <label>
                    Category ID:
                    <input value={newProduct.categoryId} onChange={(e) => setNewProduct({ ...newProduct, categoryId: e.target.value })} />
                </label>
                <button type="submit" disabled={loading}>{loading ? 'Creating...' : 'Create Product'}</button>
            </form>
        </div>
    );
}

export default ProductForm;
