import Resizer from 'react-image-file-resizer';

export const resizeFileToBlob = (file) => new Promise<Blob>(resolve => {
    Resizer.imageFileResizer(
        file,
        300,
        300,
        'JPEG',
        100,
        0,
        uri => {
            resolve(uri as Blob);
        },
        'blob',
        300,
        300,
    );
});

export const resizeFileToBase64 = (file) => new Promise<string>(resolve => {
    Resizer.imageFileResizer(
        file,
        300,
        300,
        'JPEG',
        100,
        0,
        uri => {
            resolve(uri as string);
        },
        'base64',
        300,
        300,
    );
});