import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export type ProductState = {
    products: [],
    isLoading: boolean,
}

const initialState: ProductState = {
    products: [],
    isLoading: false,
};

const product = createSlice({
    name: 'category',
    initialState,
    reducers: {
        setProducts: (state, action: PayloadAction<[]>) => {
            const products = action.payload;

            return {
                ...state,
                products,
                isLoading: false,
            };
        },
        getProducts: (state) => ({
            ...state,
            isLoading: true,
        }),
    }
});

export const {
    setProducts, getProducts,
} = product.actions;

export default product.reducer;
