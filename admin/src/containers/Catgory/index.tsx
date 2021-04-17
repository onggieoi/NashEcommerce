import React, { lazy, Suspense } from 'react';
import { Route, Switch } from 'react-router';

import InLineLoader from "src/components/InlineLoader";
import { CREATE_CATEGORY, LIST_CATEGORY } from 'src/constants/pages';

const NotFound = lazy(() => import("../NotFound"));
const Layout = lazy(() => import("../Layout"));
const ListCategory = lazy(() => import('./List'));
const CreateCategory = lazy(() => import('./Create'));

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

const Catgories = () => {
    return (
        <Switch>
            <LayoutRoute exact path={LIST_CATEGORY}>
                <ListCategory />
            </LayoutRoute>

            <LayoutRoute exact path={CREATE_CATEGORY}>
                <CreateCategory />
            </LayoutRoute>

            <Route component={NotFound} />
        </Switch>
    );
};

export default Catgories;