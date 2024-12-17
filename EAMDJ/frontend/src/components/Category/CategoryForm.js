import React, { useState } from 'react';
import { createCategory } from '../../api/category';
import { useNavigate } from 'react-router-dom';

function CategoryForm() {
    const [category, setCategory] = useState({
        name: '',
        businessId: '',
        taxIds: '', // Input for multiple tax IDs, comma-separated
    });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        try {
            // Convert comma-separated tax input into an array
            const categoryData = {
                ...category,
                taxIds: category.taxIds ? category.taxIds.split(',').map((tax) => tax.trim()) : [],
            };
            await createCategory(categoryData);
            alert('Category created successfully!');
            navigate('/category/categorylist');
        } catch (err) {
            setError('Failed to create category.');
            console.error(err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Create Category</h2>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <form onSubmit={handleSubmit}>
                <label>Name: </label>
                <input
                    type="text"
                    value={category.name}
                    onChange={(e) => setCategory({ ...category, name: e.target.value })}
                    required
                />

                <label>Business ID: </label>
                <input
                    type="text"
                    value={category.businessId}
                    onChange={(e) => setCategory({ ...category, businessId: e.target.value })}
                    required
                />

                <label>taxIds (comma-separated): </label>
                <input
                    type="text"
                    value={category.taxIds}
                    onChange={(e) => setCategory({ ...category, taxIds: e.target.value })}
                />

                <button type="submit" disabled={loading}>
                    {loading ? 'Creating...' : 'Create'}
                </button>
            </form>
        </div>
    );
}

export default CategoryForm;
