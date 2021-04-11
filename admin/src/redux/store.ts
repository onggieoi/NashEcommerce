import { configureStore, getDefaultMiddleware, combineReducers } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';

import counterReducer from './ducks/counter';
import todoReducer from './ducks/todo';
import { watcherSaga } from './sagas/rootSaga';

const reducer = combineReducers({
    counter: counterReducer,
    todo: todoReducer,
});

const sagaMiddleware = createSagaMiddleware();

const store = configureStore({
    reducer,
    middleware: [...getDefaultMiddleware({thunk: false}), sagaMiddleware]
});

sagaMiddleware.run(watcherSaga);

export default store;