import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { fetchProductsByCategory } from '../../api/product';

function ProductList() {
    const [categoryId, setCategoryId] = useState('');
    const [products, setProducts] = useState([]);
    const [loadingProducts, setLoadingProducts] = useState(false);
    const [error, setError] = useState(null);

    const handleFetchProducts = async () => {
        if (!categoryId) {
            setError('Please enter a valid category ID.');
            return;
        }

        setLoadingProducts(true);
        setError(null);
        setProducts([]);

        try {
            const response = await fetchProductsByCategory(categoryId);
            setProducts(response || []);
        } catch (err) {
            setError('Failed to fetch products. Please check the category ID.');
            console.error(err);
        } finally {
            setLoadingProducts(false);
        }
    };

    return (
        <div>
            <h2>Products</h2>

            <div>
                <label htmlFor="categoryId">Enter Category ID: </label>
                <input
                    type="text"
                    id="categoryId"
                    value={categoryId}
                    onChange={(e) => setCategoryId(e.target.value)}
                />
                <button onClick={handleFetchProducts} disabled={loadingProducts}>
                    {loadingProducts ? 'Fetching...' : 'Fetch Products'}
                </button>
            </div>

            {error && <div style={{ color: 'red' }}>{error}</div>}

            {loadingProducts ? (
                <div>Loading products...</div>
            ) : (
                <ul>
                    {products.length > 0 ? (
                        products.map((product) => (
                            <li key={product.id}>
                                <Link to={`/product/${product.id}`}>{product.name}</Link> - ${product.price}
                                <p>{product.description}</p>
                            </li>
                        ))
                    ) : (
                        <li>No products available for this category</li>
                    )}
                </ul>
            )}
        </div>
    );
}

export default ProductList;
