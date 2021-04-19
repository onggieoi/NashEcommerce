import React, { lazy, Suspense, useEffect, useState } from "react";
import { Route, Switch } from "react-router-dom";

import { DASHBOARD, AUTH, CATEGORY, PRODUCT, CUSTOMER } from "./constants/pages";
import InLineLoader from "./components/InlineLoader";
import Auth from "./containers/Auth";
import { getUser, login, logout } from "./redux/ducks/auth";
import { useAppDispatch, useAppSelector } from "./hooks/redux";

const Layout = lazy(() => import("./containers/Layout"));
const NotFound = lazy(() => import("./containers/NotFound"));
const DashBoard = lazy(() => import('./containers/DashBoard'));
const Category = lazy(() => import('./containers/Catgory'));
const Product = lazy(() => import('./containers/Product'));
const Customer = lazy(() => import('./containers/Customer'));

function PrivateRoute({ children, ...rest }) {
  const dispatch = useAppDispatch();

  const { isAuth, loading, isAuthor } = useAppSelector((state) => state.auth);

  const handleLogin = (e) => {
    e.preventDefault();

    if (isAuth && !isAuthor) dispatch(logout());
    if (!isAuth) dispatch(login());
  };

  useEffect(() => {
    if (!isAuth && !loading) {
      dispatch(login());
    }

  }, [isAuth]);

  return (
    <Route
      {...rest}
      render={({ location }) =>
        isAuth ?
          (
            <Suspense fallback={<InLineLoader />}>
              {children}
            </Suspense>
          ) : (
            <div className='text-white'>
              <div>UnAuthorization</div>
              <button onClick={handleLogin} className='button'>
                login
              </button>
            </div>
          )}
    />
  );
}

function PublicRoute({ children, ...rest }) {
  return (
    <Route {...rest}>
      <Suspense fallback={<InLineLoader />}>
        {children}
      </Suspense>
    </Route>
  );
}

const Routes = () => {
  return (
    <Suspense fallback={<InLineLoader />}>
      <Switch>

        <PrivateRoute exact={true} path={DASHBOARD} >
          <Layout>
            <DashBoard />
          </Layout>
        </PrivateRoute>

        <PrivateRoute path={CATEGORY} >
          <Category />
        </PrivateRoute>

        <PrivateRoute path={PRODUCT} >
          <Product />
        </PrivateRoute>

        <PrivateRoute path={CUSTOMER} >
          <Customer />
        </PrivateRoute>

        <PublicRoute path={AUTH}>
          <Auth />
        </PublicRoute>

        <Route component={NotFound} />

      </Switch>
    </Suspense>
  );
};

export default Routes;
