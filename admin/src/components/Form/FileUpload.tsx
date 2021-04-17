import React, { InputHTMLAttributes, useState } from 'react';
import { useField } from 'formik';
import { X } from 'react-feather';

import { resizeFileToBase64, resizeFileToBlob } from 'src/services/resizeImage';

type Props = InputHTMLAttributes<HTMLInputElement> & {
    label: string;
    name: string;
};

const FileUpload: React.FC<Props> = (props) => {
    const [, , { setValue }] = useField(props);
    const [review, setReview] = useState('');

    const handleOnChange = async (e) => {
        e.preventDefault();
        const image = await resizeFileToBlob(e.target.files[0]);
        const imageBase64 = await resizeFileToBase64(e.target.files[0]);

        setReview(imageBase64);
        setValue(image);
    }

    const handleRemove = () => {
        setValue('');
        setReview('');
    }

    return (
        <div className='mb-3'>
            <label>{props.label}: </label>
            <input type="file" onChange={handleOnChange} formEncType='multipart/form-data' name={props.name} />
            {
                review && (
                    <div className='p-5 my-3 overflow-hidden bg-gray-300 grid gap-3 grid-cols-12 mx-auto'
                        style={{ maxWidth: '1000px', maxHeight: '500px' }}>
                        <div className='col-span-4 relative'>
                            <button onClick={handleRemove} type='button'
                                className='absolute top-0 right-0 text-white'><X />
                            </button>
                            <img src={review} className='object-center w-full rounded-md' />
                        </div>
                    </div>
                )
            }
        </ div>
    );
};

export default FileUpload;
