import { createSlice } from "@reduxjs/toolkit";
import { User } from "oidc-client";

type AuthState = {
    isAuth: boolean,
    user: User,
}

const initialState: AuthState = {
    isAuth: false,
    user: {} as User,
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
            };
        },
        setAuthen: (state, action) => {
            const { isAuth } = action.payload;
            
            return {
                ...state,
                isAuth,
            }
        },
        getUser: () => {
        },
        loginCallBack: () => {
        },
        login: () => { 
        },
        logout: () => {},
        logoutCallBack: () => { },
    }
});

export const { 
    setUser, loginCallBack, getUser, login, setAuthen, logout, logoutCallBack,
} = auth.actions;

export default auth.reducer;
