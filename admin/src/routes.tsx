import React, { useContext, lazy, Suspense, useEffect } from "react";
import { Route, Switch, Redirect, useHistory } from "react-router-dom";

import { LOGIN, DASHBOARD, AUTH } from "./constants/pages";
import InLineLoader from "./components/InlineLoader";
import Auth from "./containers/Auth";
import { useDispatch, useSelector } from "react-redux";
import { getUser } from "./redux/ducks/auth";

const Layout = lazy(() => import("./containers/Layout"));
const NotFound = lazy(() => import("./containers/NotFound"));
const DashBoard = lazy(() => import('./containers/DashBoard'));

function PrivateRoute({ children, ...rest }) {
  const history = useHistory();
  const dispatch = useDispatch();

  const { isAuth } = useSelector((state: any) => state.auth);

  useEffect(() => {
    dispatch(getUser());
  }, []);

  return (
    <Route
      {...rest}
      render={({ location }) =>
        isAuth &&
        (
          <Layout>
            <Suspense fallback={<InLineLoader />}>
              {children}
            </Suspense>
          </Layout>
        )
      }
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
          <DashBoard />
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
