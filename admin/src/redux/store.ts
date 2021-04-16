import { configureStore, getDefaultMiddleware, combineReducers } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';

import authReducer from './ducks/auth';
import categoryReducer from './ducks/category';

import { watcherSaga } from './sagas/rootSaga';

const reducer = combineReducers({
    auth: authReducer,
    category: categoryReducer,
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
