import React, { useState } from 'react';
import { createCategory } from '../../api/category';

const CategoryForm = ({ businessId, onCategoryCreated }) => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
        const data = {
            name,
            description,
            businessId,
        };
        const category = await createCategory(data);
        onCategoryCreated(category);
        setName('');
        setDescription('');
        } catch (error) {
        console.error(error);
        }
    };
    
    return (
        <form onSubmit={handleSubmit}>
        <div>
            <label htmlFor="name">Name</label>
            <input
            type="text"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            />
        </div>
        <div>
            <label htmlFor="description">Description</label>
            <textarea
            id="description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            ></textarea>
        </div>
        <button type="submit">Create Category</button>
        </form>
    );
};

export default CategoryForm;