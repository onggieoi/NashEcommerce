export default interface ICategoryRequest {
    categoryId?: number,
    name: string;
    description: string;
    image?: string;
    imageFile?: Blob;
}