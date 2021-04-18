import React, { lazy, Suspense } from 'react';
import { Route, Switch } from 'react-router';

import InLineLoader from "src/components/InlineLoader";
import { CUSTOMER, } from 'src/constants/pages';

const NotFound = lazy(() => import("../NotFound"));
const Layout = lazy(() => import("../Layout"));
const ListCustomer = lazy(() => import('./List'));

function LayoutRoute({ children, ...rest }) {
    return (
        <Route {...rest}>
            <Suspense fallback={<InLineLoader />}>
                <Layout>
                    {children}
                </Layout>
            </Suspense>
        </Route>
    );
}

const Customer = () => {
    return (
        <Switch>
            <LayoutRoute exact path={CUSTOMER}>
                <ListCustomer />
            </LayoutRoute>

            <Route component={NotFound} />
        </Switch>
    );
};

export default Customer;