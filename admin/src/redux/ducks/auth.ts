import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    
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
        setLoading: (state) => {
          return {
            ...state,
            isLoad: true,
        }},
        getUser: (state) => {
            console.log('getUser', state);
        },
        loginCallBack: (state) => {
            console.log('loginCallBack', state);
        },
        login: (state) => { 
            console.log('login', state);
        }
    }
});

export const { 
  setUser, loginCallBack, getUser, login, setAuthen, setLoading,
} = auth.actions;

export default auth.reducer;
