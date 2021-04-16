import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import IProduct from "src/interfaces/IProduct";

export type ProductState = {
    products: IProduct[],
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
        setProducts: (state, action: PayloadAction<IProduct[]>) => {
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
