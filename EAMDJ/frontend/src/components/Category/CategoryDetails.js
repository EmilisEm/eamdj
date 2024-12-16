import React from 'react';

const CategoryDetails = ({ category }) => {
    return (
        <div className="category-details">
        <h2>{category.name}</h2>
        <p>{category.description}</p>
        </div>
    );
};

export default CategoryDetails;
