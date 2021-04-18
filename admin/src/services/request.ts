import axios, { AxiosInstance, AxiosRequestConfig } from "axios";

import { UrlBackEnd } from "src/constants/configs";

const config: AxiosRequestConfig = {
    baseURL: UrlBackEnd
}

class RequestService {
    public axios: AxiosInstance;

    constructor() {
        this.axios = axios.create(config);
    }

    public setAuthentication(accessToken: string) {
        this.axios.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;
    }
}

export default new RequestService();
