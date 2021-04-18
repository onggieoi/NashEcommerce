export default interface IProductRequest {
    productId?: number;
    name: string;
    price: number;
    image?: string;
    description: string;
    categoryId: number;
    imageFile?: Blob;
}