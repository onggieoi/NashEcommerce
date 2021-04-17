import React, { InputHTMLAttributes } from 'react';
import { useField } from 'formik';

type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
    label: string;
    placeholder?: string;
    name: string;
};

const TextField: React.FC<InputFieldProps> = (props) => {
    const [field, { error, touched }] = useField(props);

    const validateClass = () => {
        if (touched && error) return 'border-theme-6';

        if (touched) return 'border-theme-9';
        return '';
    };

    return (
        // <div className='mb-3'>
        //     <label className='ml-2'>{props.label}: </label>
        //     <input className={`input w-full border mt-2 ${validateClass()}`} {...field} {...props} />
        //     {
        //         touched && error ? (
        //             <p className='text-theme-6 mt-1'>{error}</p>
        //         ) : null
        //     }
        // </div>

        <div className='mb-3'>
            <label>{props.label}</label>
            <input className={`input w-full border mt-2 ${validateClass()}`} {...field} {...props} />
            {
                touched && error ? (
                    <p className='text-theme-6 mt-1'>{error}</p>
                ) : null
            }
        </div>
    );
};
export default TextField;
