import React, { lazy, Suspense, useEffect } from "react";
import { Route, Switch } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";

import { DASHBOARD, AUTH, CATEGORY, PRODUCT } from "./constants/pages";
import InLineLoader from "./components/InlineLoader";
import Auth from "./containers/Auth";
import { getUser } from "./redux/ducks/auth";

const Layout = lazy(() => import("./containers/Layout"));
const NotFound = lazy(() => import("./containers/NotFound"));
const DashBoard = lazy(() => import('./containers/DashBoard'));
const Category = lazy(() => import('./containers/Catgory'));
const Product = lazy(() => import('./containers/Product'));

function PrivateRoute({ children, ...rest }) {
  const dispatch = useDispatch();

  const { isAuth } = useSelector((state: any) => state.auth);

  useEffect(() => {
    // dispatch(getUser());
  }, []);

  return (
    <Route
      {...rest}
      render={({ location }) =>
      // isAuth && 
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

        <PublicRoute path={AUTH}>
          <Auth />
        </PublicRoute>

        <Route component={NotFound} />

      </Switch>
    </Suspense>
  );
};

export default Routes;
