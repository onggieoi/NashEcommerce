import React, { lazy, Suspense, useEffect } from "react";
import { Route, Switch } from "react-router-dom";

import { DASHBOARD, AUTH, CATEGORY, PRODUCT, CUSTOMER } from "./constants/pages";
import InLineLoader from "./components/InlineLoader";
import Auth from "./containers/Auth";
import { login } from "./redux/ducks/auth";
import { useAppDispatch, useAppSelector } from "./hooks/redux";
import Loading from "./components/Loading";

const Layout = lazy(() => import("./containers/Layout"));
const NotFound = lazy(() => import("./containers/NotFound"));
const DashBoard = lazy(() => import('./containers/DashBoard'));
const Category = lazy(() => import('./containers/Catgory'));
const Product = lazy(() => import('./containers/Product'));
const Customer = lazy(() => import('./containers/Customer'));
const UnAuthorization = lazy(() => import('./containers/UnAuthorization'));

function PrivateRoute({ children, ...rest }) {
  const dispatch = useAppDispatch();

  const { isAuth, loading, isAuthor } = useAppSelector((state) => state.auth);

  const handleLogin = (e) => {
    e.preventDefault();
    dispatch(login());
  };

  useEffect(() => {
    if (!isAuth && !loading) {
      dispatch(login());
    }

  }, [isAuth]);

  if (isAuth && !isAuthor) return <UnAuthorization />

  if (!isAuth) return (
    <div className='text-white'>
      <div>UnAuthorization</div>
      <button onClick={handleLogin} className='button'>
        login
      </button>
    </div>
  )

  return (
    <Route
      {...rest}
      render={({ location }) =>
        (isAuth && isAuthor) &&
        (
          <Suspense fallback={<InLineLoader />}>
            {children}
          </Suspense>
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
