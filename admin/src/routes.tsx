import React, { useContext, lazy, Suspense } from "react";
import { Route, Switch, Redirect } from "react-router-dom";

import { LOGIN, DASHBOARD } from "./constants/pages";
import AuthProvider, { AuthContext } from "./contexts/auth";
import InLineLoader from "./components/InlineLoader";
import Auth from "./containers/Auth";

const Layout = lazy(() => import("./containers/Layout"));
const Home = lazy(() => import("./containers/Home"));
const Login = lazy(() => import("./containers/Login"));
const NotFound = lazy(() => import("./containers/NotFound"));
const DashBoard = lazy(() => import('./containers/DashBoard'));

function PrivateRoute({ children, ...rest }) {
  const { isAuthenticated } = useContext(AuthContext);

  return (
    <Route
      {...rest}
      render={({ location }) =>
        isAuthenticated ? (
          <Layout>
            <Suspense fallback={<InLineLoader />}>
              {children}
            </Suspense>
          </Layout>
        ) : (
          <Redirect
            to={{
              pathname: "/login",
              state: { from: location }
            }}
          />
        )
      }
    />
  );
}

function PublicRoute({ children, ...rest }) {
  return (
    <Route {...rest}>
      <Layout>
        <Suspense fallback={<InLineLoader />}>
          {children}
        </Suspense>
      </Layout>
    </Route>
  );
}

const Routes = () => {
  return (
    <AuthProvider>
      <Suspense fallback={<InLineLoader />}>
        <Switch>

          <PublicRoute exact={true} path={DASHBOARD}>
            <DashBoard />
          </PublicRoute>

          <Route path="/authentication/:action">
            <Auth />
          </Route>

          <Route path={LOGIN}>
            <Login />
          </Route>

          <Route component={NotFound} />

        </Switch>
      </Suspense>
    </AuthProvider>
  );
};

export default Routes;
