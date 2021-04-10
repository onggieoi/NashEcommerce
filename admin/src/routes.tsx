import React, { useContext, lazy, Suspense } from "react";
import { Route, Switch, Redirect } from "react-router-dom";

import { LOGIN, HOME } from "./constants/pages";
import AuthProvider, { AuthContext } from "./contexts/auth";
import InLineLoader from "./components/InlineLoader";

const Layout = lazy(() => import("./containers/Layout"));
const Home = lazy(() => import("./containers/Home"));
const Login = lazy(() => import("./containers/Login"));
const NotFound = lazy(() => import("./containers/NotFound"));

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

          <PublicRoute exact={true} path={HOME}>
            <Home />
          </PublicRoute>

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
