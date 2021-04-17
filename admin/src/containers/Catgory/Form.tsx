import React from 'react';
import { Form, Formik } from 'formik';
import TextField from 'src/components/Form/TextField';
import FileUpload from 'src/components/Form/FileUpload';

const initialValues = {
    name: '',
    quantity: 0,
    image: '',
}

type Props = {
    initialForm?: {};
}

const FormCategory: React.FC<Props> = ({ initialForm }) => {

    return (
        <Formik
            initialValues={initialForm || initialValues}
            onSubmit={(values, actions) => {
                actions.setSubmitting(true);
                setTimeout(() => {
                    console.log(values);
                    actions.setSubmitting(false);
                }, 1000);
            }}
        >
            {({ isSubmitting }) => (
                <Form className='intro-y box p-5'>
                    <TextField name='name' label='Name' placeholder='Product Name' />
                    <TextField name='quantity' label='Quantity' type='number' />
                    <FileUpload label="Image" name="image" />

                    <div className="text-right mt-5">
                        <button type="button" className="button w-24 border text-gray-700 mr-1">
                            Cancel
                        </button>

                        <button type="submit" className="button w-24 bg-theme-1 text-white"
                            disabled={isSubmitting}>
                            {initialForm ? 'Update' : 'Create'}
                            {isSubmitting && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                        </button>
                    </div>
                </Form>
            )}
        </Formik>
    );
};

export default FormCategory;