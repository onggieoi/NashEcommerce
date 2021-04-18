import React, { lazy, Suspense } from 'react';
import { Route, Switch } from 'react-router';

import InLineLoader from "src/components/InlineLoader";
import { CREATE_PRODUCT, EDIT_PRODUCT, LIST_PRODUCT } from 'src/constants/pages';
import CreateProduct from './Create';

const NotFound = lazy(() => import("../NotFound"));
const Layout = lazy(() => import("../Layout"));
const ListProduct = lazy(() => import('./List'));
const EditProduct = lazy(() => import('./Edit'));

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
                <CreateProduct />
            </LayoutRoute>

            <LayoutRoute exact path={EDIT_PRODUCT}>
                <EditProduct />
            </LayoutRoute>

            <Route component={NotFound} />
        </Switch>
    );
};

export default Product;