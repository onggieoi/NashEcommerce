export default interface ICategoryRequest {
    name: string;
    description: string;
    image?: string;
    imageFile?: Blob;
}