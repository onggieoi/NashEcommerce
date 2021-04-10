import React, { createContext, useState } from 'react';

type AuthProps = {
  isAuthenticated: boolean;
  signin: Function;
  signout: Function;
};

export const AuthContext = createContext<AuthProps>({} as AuthProps);

const isValidToken = () => {
  const token = localStorage.getItem('uid');
  if (token) return true;
  return false;
};

const AuthProvider = ({ children }) => {
  const [isAuthenticated, makeAuthenticated] = useState(false);

  const signin = ({ email, password }, cb) => {
    makeAuthenticated(true);
    localStorage.setItem('uid', `${email}.${password}`);
    setTimeout(cb, 100); // fake async
  }

  const signout = (cb) => {
    makeAuthenticated(false);
    localStorage.removeItem('uid');
    setTimeout(cb, 100);
  }

  return (
    <AuthContext.Provider value={{
      isAuthenticated,
      signin,
      signout,
    }}>
      {children}
    </AuthContext.Provider>
  )
}

export default AuthProvider;
