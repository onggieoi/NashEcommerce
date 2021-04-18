import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import IProduct from "src/interfaces/IProduct";
import IProductRequest from "src/interfaces/IProductRequest";

export type ProductResult = {
    product?: IProduct,
    isSuccess: boolean,
}

export type ProductState = {
    products: IProduct[],
    isLoading: boolean,
    productResult?: ProductResult,
    product?: IProduct,
}

const initialState: ProductState = {
    products: [] as IProduct[],
    isLoading: false,
};

const product = createSlice({
    name: 'product',
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
        createProduct: (state, action: PayloadAction<IProductRequest>) => ({
            ...state,
            isLoading: true,
        }),
        setProductResult: (state, action: PayloadAction<ProductResult>) => {
            const productResult = action.payload;

            return {
                ...state,
                productResult,
                isLoading: false,
            }
        },
        cleanUp: (state) => ({
            ...state,
            productResult: undefined,
            product: undefined,
        }),
        getProduct: (state, action: PayloadAction<string>) => ({
            ...state,
            isLoading: true,
        }),
        setProduct: (state, action: PayloadAction<IProduct>) => {
            const product = action.payload;
            return {
                ...state,
                product,
                isLoading: false,
            }
        },
        updateProduct: (state, action: PayloadAction<IProductRequest>) => ({
            ...state,
            isLoading: true,
        }),
        deleteProduct: (state, action: PayloadAction<string>) => ({
            ...state,
            isLoading: true,
        }),
    }
});

export const {
    setProducts, getProducts, createProduct, setProductResult, cleanUp, getProduct, setProduct, updateProduct, deleteProduct,
} = product.actions;

export default product.reducer;
