import { configureStore, getDefaultMiddleware, combineReducers } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';

import authReducer from './ducks/auth';

import { watcherSaga } from './sagas/rootSaga';

const reducer = combineReducers({
    auth: authReducer,
});

const sagaMiddleware = createSagaMiddleware();

const store = configureStore({
    reducer,
    middleware: [...getDefaultMiddleware({thunk: false}), sagaMiddleware]
});

sagaMiddleware.run(watcherSaga);

export default store;