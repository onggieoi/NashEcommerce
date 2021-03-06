export const DASHBOARD = '/';
export const AUTH = '/authentication/:action';
export const LOGIN = '/authentication/login';

export const CATEGORY = '/category';
export const LIST_CATEGORY = '/category/';
export const CREATE_CATEGORY = '/category/create';
export const EDIT_CATEGORY = '/category/edit/:id';
export const editPage = (id: number): string => `/category/edit/${id}`;

export const PRODUCT = '/product';
export const LIST_PRODUCT = '/product/';
export const CREATE_PRODUCT = '/product/create';
export const EDIT_PRODUCT = '/product/edit/:id';
export const toEditProductPage = (id: number): string => `/product/edit/${id}`;

export const CUSTOMER = '/customer';
