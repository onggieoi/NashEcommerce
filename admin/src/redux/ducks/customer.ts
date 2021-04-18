import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import ICustomer from "src/interfaces/ICustomer";

export type CategoryState = {
    customers: ICustomer[],
    isLoading: boolean,
}

const initialState: CategoryState = {
    customers: [] as ICustomer[],
    isLoading: false,
};

const customer = createSlice({
    name: 'customer',
    initialState,
    reducers: {
        setCustomers: (state, action: PayloadAction<ICustomer[]>) => {
            const customers = action.payload;

            return {
                ...state,
                customers,
                isLoading: false,
            };
        },
        getCustomers: (state) => ({
            ...state,
            isLoading: true,
        }),
    }
});

export const {
    setCustomers, getCustomers,
} = customer.actions;

export default customer.reducer;
