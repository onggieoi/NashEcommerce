import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import ICategory from "src/interfaces/ICategory";

export type CategoryState = {
    categories: ICategory[],
    isLoading: boolean
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
    }
});

export const {
    setCatgories, getCatgories,
} = catgory.actions;

export default catgory.reducer;
