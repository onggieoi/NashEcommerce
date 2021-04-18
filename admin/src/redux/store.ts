import { configureStore, getDefaultMiddleware, combineReducers } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';

import authReducer from './ducks/auth';
import categoryReducer from './ducks/category';
import customerReducer from './ducks/customer';
import productReducer from './ducks/product';

import { watcherSaga } from './sagas/rootSaga';

const reducer = combineReducers({
    auth: authReducer,
    category: categoryReducer,
    product: productReducer,
    customer: customerReducer,
});

const sagaMiddleware = createSagaMiddleware();

const store = configureStore({
    reducer,
    middleware: [...getDefaultMiddleware({thunk: false}), sagaMiddleware]
});

sagaMiddleware.run(watcherSaga);

export default store;

export type RootState = ReturnType<typeof store.getState>
export type RootDispatch = typeof store.dispatch
