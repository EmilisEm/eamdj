import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { fetchProductById, updateProduct, deleteProduct } from '../../api/product';

function ProductDetails() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [product, setProduct] = useState(null);
    const [isEditing, setIsEditing] = useState(false);

    useEffect(() => {
        if (!id) {
            console.error('Product ID is missing');
            navigate('/product/productlist');
            return;
        }

        const getProduct = async () => {
            try {
                const productData = await fetchProductById(id);
                setProduct(productData);
            } catch (error) {
                console.error('Failed to fetch product:', error);
                navigate('/product/productlist');
            }
        };

        getProduct();
    }, [id, navigate]);

    if (!product) return <div>Loading...</div>;

    const handleUpdate = async () => {
        try {
            await updateProduct(id, product);
            alert('Product updated!');
            navigate('/product/productlist');
        } catch (error) {
            console.error('Failed to update product:', error);
            alert('Failed to update product');
        }
    };

    const handleDelete = async () => {
        if (window.confirm('Are you sure you want to delete this product?')) {
            try {
                await deleteProduct(id);
                alert('Product deleted!');
                navigate('/product/productlist');
            } catch (error) {
                console.error('Failed to delete product:', error);
                alert('Failed to delete product');
            }
        }
    };

    const handleChange = (field, value) => {
        setProduct((prev) => ({ ...prev, [field]: value }));
    };

    return (
        <div>
            <h2>Product Details</h2>
            <p>
                Name:
                <input
                    value={product.name}
                    onChange={(e) => handleChange('name', e.target.value)}
                    disabled={!isEditing}
                />
            </p>
            <p>
                Price:
                <input
                    value={product.price}
                    onChange={(e) => handleChange('price', e.target.value)}
                    disabled={!isEditing}
                />
            </p>
            <p>
                Description:
                <input
                    value={product.description}
                    onChange={(e) => handleChange('description', e.target.value)}
                    disabled={!isEditing}
                />
            </p>

            {isEditing ? (
                <button onClick={handleUpdate}>Save</button>
            ) : (
                <button onClick={() => setIsEditing(true)}>Edit</button>
            )}
            <button onClick={handleDelete}>Delete</button>

            <button onClick={() => navigate(`/product/${id}/modifiers`)}>Manage Modifiers</button>
        </div>
    );
}

export default ProductDetails;
