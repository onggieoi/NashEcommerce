import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { User } from "oidc-client";

import RequestService from 'src/services/request';

type AuthState = {
    loading: boolean;
    isAuth: boolean,
    isAuthor: boolean,
    user: User,
}

const initialState: AuthState = {
    isAuth: false,
    user: {} as User,
    loading: false,
    isAuthor: false,
};

const auth = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setUser: (state, action: PayloadAction<User>) => {
            const user = action.payload;

            if (user.profile.role === 'ADMIN') {
                RequestService.setAuthentication(user.access_token);

                return { 
                    ...state,
                    user,
                    isAuth: true,
                    loading: false,
                    isAuthor: true,
                };
            }

            return {
                ...state,
                isAuthor: false,
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
            isAuth: false,
            loading: true,
        }),
        logoutCallBack: (state) => ({
            ...state,
            isAuth: false,
            loading: true,
            isAuthor: false,
        }),
    }
});

export const { 
    setUser, loginCallBack, getUser, login, setAuthen, logout, logoutCallBack,
} = auth.actions;

export default auth.reducer;
