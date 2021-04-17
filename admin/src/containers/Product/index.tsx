import React, { lazy, Suspense } from 'react';
import { Route, Switch } from 'react-router';

import InLineLoader from "src/components/InlineLoader";
import { CREATE_PRODUCT, LIST_PRODUCT } from 'src/constants/pages';

const NotFound = lazy(() => import("../NotFound"));
const Layout = lazy(() => import("../Layout"));
const ListProduct = lazy(() => import('./List'));

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

const Product = () => {
    return (
        <Switch>
            <LayoutRoute exact path={LIST_PRODUCT}>
                <ListProduct />
            </LayoutRoute>

            <LayoutRoute exact path={CREATE_PRODUCT}>
                <div>Create Product</div>
            </LayoutRoute>

            <Route component={NotFound} />
        </Switch>
    );
};

export default Product;