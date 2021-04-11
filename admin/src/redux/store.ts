import { combineReducers, createStore } from 'redux';

import counterReducer from './ducks/counter';

const reducers = combineReducers({
    counter: counterReducer,
});

const store = createStore(reducers);

export default store;