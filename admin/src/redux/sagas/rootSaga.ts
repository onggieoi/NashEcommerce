import {takeLatest} from 'redux-saga/effects';

import { 
    getUser, login, loginCallBack, logout, logoutCallBack
} from '../ducks/auth';
import { 
    handleCompleteLogin, handleGetUser, handleLogin, handleLogout, handleLogoutCallBack 
} from './handlers/auth';

import { createCategory, deleteCategory, getCategory, getCatgories, updateCatgegory } from '../ducks/category';
import { handleCreateCategory, handleDeleteCategory, handleGetCategory, handleGetCategoryById, handleUpdateCategory } from './handlers/category';

import { getProducts } from '../ducks/product';
import { handleGetProduct } from './handlers/product';

export function* watcherSaga() {
    yield takeLatest(getUser.type, handleGetUser);
    yield takeLatest(loginCallBack.type, handleCompleteLogin);
    yield takeLatest(login.type, handleLogin);
    yield takeLatest(logout.type, handleLogout);
    yield takeLatest(logoutCallBack.type, handleLogoutCallBack);

    yield takeLatest(getCatgories.type, handleGetCategory);
    yield takeLatest(createCategory.type, handleCreateCategory);
    yield takeLatest(getCategory.type, handleGetCategoryById);
    yield takeLatest(updateCatgegory.type, handleUpdateCategory);
    yield takeLatest(deleteCategory.type, handleDeleteCategory);

    yield takeLatest(getProducts.type, handleGetProduct);
}