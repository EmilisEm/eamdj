import React from "react";

const ReservationForm = ({ businesses, onSubmit }) => {
    const [formData, setFormData] = React.useState({
        reservationDate: "",
        reservationTime: "",
        businessId: "",
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(formData);
    };

    return (
        <form onSubmit={handleSubmit}>
        <h2>Reservation Form</h2>
        <label>
            Reservation Date:
            <input
            type="date"
            name="reservationDate"
            value={formData.reservationDate}
            onChange={handleChange}
            />
        </label>
        <br />
        <label>
            Reservation Time:
            <input
            type="time"
            name="reservationTime"
            value={formData.reservationTime}
            onChange={handleChange}
            />
        </label>
        <br />
        <label>
            Business:
            <select name="businessId" onChange={handleChange}>
            <option value="">--Please choose a business--</option>
            {businesses.map((business) => (
                <option key={business.id} value={business.id}>
                {business.name}
                </option>
            ))}
            </select>
        </label>
        <br />
        <button type="submit">Submit</button>
        </form>
    );
}

export default ReservationForm;