import { AxiosResponse } from "axios";

import { EndPoints } from "src/constants/configs";
import ICustomer from "src/interfaces/ICustomer";
import RequestService from 'src/services/request';

export function requestGetCustomers(): Promise<AxiosResponse<ICustomer[]>> {
    return RequestService.axios.get(EndPoints.Customers);
}