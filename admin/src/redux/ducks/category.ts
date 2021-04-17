import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import ICategory from "src/interfaces/ICategory";
import ICategoryRequest from "src/interfaces/ICategoryRequest";

export type CreateResult = {
    category?: ICategory,
    isSuccess: boolean,
}

export type CategoryState = {
    categories: ICategory[],
    isLoading: boolean,
    createResult?: CreateResult,
}

const initialState: CategoryState = {
    categories: [],
    isLoading: false,
};

const catgory = createSlice({
    name: 'category',
    initialState,
    reducers: {
        setCatgories: (state, action: PayloadAction<ICategory[]>) => {
            const categories = action.payload;
            
            return {
                ...state,
                categories,
                isLoading: false,
            };
        },
        getCatgories: (state) => ({
            ...state,
            isLoading: true,
        }),
        createCategory: (state, action: PayloadAction<ICategoryRequest>) => ({
            ...state,
            isLoading: true,
        }),
        setCreateResult: (state, action: PayloadAction<CreateResult>) => {
            const createResult = action.payload;
            
            return {
                ...state,
                createResult,
                isLoading: false,
            }
        },
    }
});

export const {
    setCatgories, getCatgories, createCategory, setCreateResult,
} = catgory.actions;

export default catgory.reducer;
