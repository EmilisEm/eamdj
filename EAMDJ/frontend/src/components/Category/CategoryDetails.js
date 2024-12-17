import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { fetchCategoryById, updateCategory, deleteCategory } from '../../api/category';

function CategoryDetails() {
    const { id } = useParams();
    const [category, setCategory] = useState({
        name: '',
        businessId: '',
        taxes: [],
    });
    const [isEditing, setIsEditing] = useState(false);
    const navigate = useNavigate();

    // Fetch category details when the component mounts
    useEffect(() => {
        const getCategory = async () => {
            try {
                const data = await fetchCategoryById(id); // Fetch a single category
                setCategory({
                    ...data,
                    taxes: data.taxes || [], // Ensure taxes is an array
                });
            } catch (err) {
                console.error('Error fetching category:', err);
            }
        };

        getCategory();
    }, [id]);

    const handleUpdate = async () => {
        try {
            const updatedCategory = {
                ...category,
                taxes: Array.isArray(category.taxes)
                    ? category.taxes
                    : category.taxes.split(',').map((tax) => tax.trim()),
            };

            await updateCategory(id, updatedCategory);
            alert('Category updated successfully!');
            navigate('/category/categorylist'); // Redirect to the category list
        } catch (err) {
            console.error('Error updating category:', err);
            alert('Failed to update category.');
        }
    };



    const handleDelete = async () => {
        if (window.confirm('Are you sure you want to delete this category?')) {
            try {
                await deleteCategory(id);
                alert('Category deleted successfully.');
                navigate('/category/categorylist');
            } catch (err) {
                console.error('Error deleting category:', err);
            }
        }
    };

    return (
        <div>
            <h2>Category Details</h2>
            <label>Name: </label>
            <input
                type="text"
                value={category.name}
                onChange={(e) => setCategory({ ...category, name: e.target.value })}
                disabled={!isEditing}
            />

            <label>Business ID: </label>
            <input
                type="text"
                value={category.businessId}
                disabled
            />

            <label>Taxes (comma-separated): </label>
            <input
                type="text"
                value={isEditing ? category.taxes.join(', ') : category.taxes.join(', ')}
                onChange={(e) => setCategory({ ...category, taxes: e.target.value.split(',') })}
                disabled={!isEditing}
            />

            <div>
                {isEditing ? (
                    <button onClick={handleUpdate}>Save</button>
                ) : (
                    <button onClick={() => setIsEditing(true)}>Edit</button>
                )}
                <button onClick={handleDelete} style={{ marginLeft: '10px' }}>
                    Delete
                </button>
            </div>
        </div>
    );
}

export default CategoryDetails;
