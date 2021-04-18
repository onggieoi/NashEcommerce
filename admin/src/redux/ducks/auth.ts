import { createSlice } from "@reduxjs/toolkit";
import { User } from "oidc-client";

type AuthState = {
    loading: boolean;
    isAuth: boolean,
    user: User,
}

const initialState: AuthState = {
    isAuth: false,
    user: {} as User,
    loading: false,
};

const auth = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setUser: (state, action) => {
            const user = action.payload;

            return { 
                ...state,
                user,
                isAuth: true,
                loading: false,
            };
        },
        setAuthen: (state, action) => {
            const { isAuth } = action.payload;
            
            return {
                ...state,
                isAuth,
                loading: false,
            }
        },
        getUser: (state) => ({
            ...state,
            loading: true,
        }),
        loginCallBack:(state) => ({
            ...state,
            loading: true,
        }),
        login: (state) => ({
            ...state,
            loading: true,
        }),
        logout: (state) => ({
            ...state,
            loading: true,
        }),
        logoutCallBack: (state) => ({
            ...state,
            loading: true,
        }),
    }
});

export const { 
    setUser, loginCallBack, getUser, login, setAuthen, logout, logoutCallBack,
} = auth.actions;

export default auth.reducer;
