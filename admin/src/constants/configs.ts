export const UrlBackEnd = process.env.REACT_APP_BACKEND_URL;

export const URL = process.env.REACT_APP_URL;

export const CallBackEndpoints = {
    redirect_uri: `${URL}/authentication/login-callback`,
    post_logout_redirect_uri: `${URL}/authentication/logout-callback`,
};

export const EndPoints = {
    Products: `${UrlBackEnd}/api/products`,
    Product: (id: number | string): string => `${UrlBackEnd}/${id}`,
    Categories: `${UrlBackEnd}/api/categories`,
    Category: (id: number | string): string => `${UrlBackEnd}/${id}`,
};
