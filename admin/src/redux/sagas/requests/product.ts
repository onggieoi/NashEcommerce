import axios from "axios";

export function requestGetProduct() {
    return axios.get('https://localhost:5000/api/products');
}
