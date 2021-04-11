import {takeLatest} from 'redux-saga/effects';

import { getTodos } from '../ducks/todo';
import { handleGetUser } from './handlers/todo';

export function* watcherSaga() {
    yield takeLatest(getTodos.type, handleGetUser)
}