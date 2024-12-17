import React, { useState, useEffect } from 'react';
import { fetchBusinesses } from '../../api/business';
import { fetchCategoriesByBusiness } from '../../api/category';
import { Link } from 'react-router-dom';

function CategoryList() {
    const [businesses, setBusinesses] = useState([]);
    const [categories, setCategories] = useState([]);
    const [selectedBusiness, setSelectedBusiness] = useState('');
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        const getBusinesses = async () => {
            try {
                const data = await fetchBusinesses();
                setBusinesses(data);
            } catch (err) {
                console.error('Error fetching businesses:', err);
            }
        };

        getBusinesses();
    }, []);

    const handleBusinessSelect = async (businessId) => {
        setSelectedBusiness(businessId);
        setLoading(true);
        try {
            const data = await fetchCategoriesByBusiness(businessId);
            setCategories(data);
        } catch (err) {
            console.error('Error fetching categories:', err);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Categories</h2>
            <label>Select a Business: </label>
            <select onChange={(e) => handleBusinessSelect(e.target.value)}>
                <option value="">-- Select Business --</option>
                {businesses.map((business) => (
                    <option key={business.id} value={business.id}>
                        {business.name}
                    </option>
                ))}
            </select>

            {loading && <p>Loading categories...</p>}
            <ul>
                {categories.length > 0 ? (
                    categories.map((category) => (
                        <li key={category.id}>
                            <Link to={`/category/${category.id}`}>{category.name}</Link> (taxIds: {category.taxes.length || 0})
                        </li>
                    ))
                ) : (
                    <p>No categories available for the selected business.</p>
                )}
            </ul>
        </div>
    );
}

export default CategoryList;
