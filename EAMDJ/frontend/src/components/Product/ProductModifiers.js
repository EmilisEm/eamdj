import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { fetchProductModifiers, createModifier, updateModifier, deleteModifier } from '../../api/modifier';
import { fetchProductById } from '../../api/product';

function ProductModifiers() {
    const { id: productId } = useParams();
    const [productName, setProductName] = useState('');
    const [modifiers, setModifiers] = useState([]);
    const [newModifier, setNewModifier] = useState({ name: '', price: '', productId });
    const [isEditing, setIsEditing] = useState(false);
    const [editingModifier, setEditingModifier] = useState(null);

    useEffect(() => {
        const getProductDetails = async () => {
            try {
                const product = await fetchProductById(productId);
                setProductName(product.name);
            } catch (error) {
                console.error('Failed to fetch product details:', error);
            }
        };

        const getModifiers = async () => {
            try {
                const data = await fetchProductModifiers(productId);
                setModifiers(data);
            } catch (error) {
                console.error('Failed to fetch modifiers:', error);
            }
        };

        getProductDetails();
        getModifiers();
    }, [productId]);

    const handleAddModifier = async () => {
        try {
            const createdModifier = await createModifier(newModifier);
            setModifiers((prev) => [...prev, createdModifier]);
            setNewModifier({ name: '', price: '', productId });
        } catch (error) {
            console.error('Failed to create modifier:', error);
        }
    };

    const handleEditModifier = async () => {
        try {
            const updatedModifier = await updateModifier(editingModifier.id, editingModifier);

            setModifiers((prev) =>
                prev.map((mod) => (mod.id === updatedModifier.id ? updatedModifier : mod))
            );

            setIsEditing(false);
            setEditingModifier(null);
        } catch (error) {
            console.error('Failed to update modifier:', error);
        }
    };


    const handleDeleteModifier = async (id) => {
        try {
            await deleteModifier(id);
            setModifiers((prev) => prev.filter((mod) => mod.id !== id));
        } catch (error) {
            console.error('Failed to delete modifier:', error);
        }
    };

    return (
        <div>
            <h2>Modifiers for Product: {productName || 'Loading...'}</h2>
            <ul>
                {modifiers.map((mod) => (
                    <li key={mod.id}>
                        <span>{mod.name} - ${mod.price}</span>
                        <button onClick={() => {
                            setIsEditing(true);
                            setEditingModifier(mod);
                        }}>
                            Edit
                        </button>
                        <button onClick={() => handleDeleteModifier(mod.id)}>Delete</button>
                    </li>
                ))}
            </ul>
            <div>
                {isEditing ? (
                    <div>
                        <h3>Edit Modifier</h3>
                        <input
                            type="text"
                            value={editingModifier?.name || ''}
                            onChange={(e) =>
                                setEditingModifier((prev) => ({ ...prev, name: e.target.value }))
                            }
                        />
                        <input
                            type="number"
                            value={editingModifier?.price || ''}
                            onChange={(e) =>
                                setEditingModifier((prev) => ({ ...prev, price: e.target.value }))
                            }
                        />
                        <button onClick={handleEditModifier}>Save</button>
                        <button onClick={() => setIsEditing(false)}>Cancel</button>
                    </div>
                ) : (
                    <div>
                        <h3>Add New Modifier</h3>
                        <input
                            type="text"
                            placeholder="Name"
                            value={newModifier.name}
                            onChange={(e) =>
                                setNewModifier((prev) => ({ ...prev, name: e.target.value }))
                            }
                        />
                        <input
                            type="number"
                            placeholder="Price"
                            value={newModifier.price}
                            onChange={(e) =>
                                setNewModifier((prev) => ({ ...prev, price: e.target.value }))
                            }
                        />
                        <button onClick={handleAddModifier}>Add</button>
                    </div>
                )}
            </div>
        </div>
    );
}

export default ProductModifiers;
