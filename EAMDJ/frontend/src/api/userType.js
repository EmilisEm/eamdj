export const userType = {
    employee: 0,
    businessOwner: 1,
    admin: 2,
};

const userTypeName = {
    employee: 'Employee',
    businessOwner: 'Business Owner',
    admin: 'Admin',
}

export const getUserTypeName = (value) => {
    for (let key in userType) {
        if (userType[key] === value) {
            return userTypeName[key];
        }
    }
    return null;
};