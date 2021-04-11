import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    todos: [],
};

const todo = createSlice({
    name: 'todo',
    initialState,
    reducers: {
        setTodos: (state, action) => {
            const todos = action.payload;
            return { ...state, todos };
        },
        getTodos() {},
    }
});

export const { setTodos, getTodos } = todo.actions;

export default todo.reducer;
