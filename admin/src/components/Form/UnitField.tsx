import React, { InputHTMLAttributes } from 'react';
import { useField } from 'formik';

type InputFieldProps = InputHTMLAttributes<HTMLInputElement> & {
    label: string;
    placeholder?: string;
    name: string;
    unit: string;
};

const TextField: React.FC<InputFieldProps> = (props) => {
    const [field, { error, touched }] = useField(props);

    const validateClass = () => {
        if (touched && error) return 'border-theme-6';

        if (touched) return 'border-theme-9';
        return '';
    };

    return (
        <div className='mb-3'>
            <label>{props.label}</label>
            <div className="relative mt-2">
                <input className={`input pr-12 w-full border col-span-4 ${validateClass()}`} {...field} {...props} />
                <div className="absolute top-0 right-0 rounded-r w-10 h-full flex items-center justify-center bg-gray-100 border text-gray-600">
                    {props.unit}
                </div>
            </div>
            {
                touched && error ? (
                    <p className='text-theme-6 mt-1'>{error}</p>
                ) : null
            }
        </div>
    );
};
export default TextField;
