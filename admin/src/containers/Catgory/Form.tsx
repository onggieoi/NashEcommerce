import React, { useEffect } from 'react';
import { Form, Formik } from 'formik';
import { NotificationManager } from 'react-notifications';
import NProgress from 'nprogress';

import TextField from 'src/components/Form/TextField';
import FileUpload from 'src/components/Form/FileUpload';
import ICategoryRequest from 'src/interfaces/ICategoryRequest';
import { useDispatch } from 'react-redux';
import { cleanUp, createCategory } from 'src/redux/ducks/category';
import { useAppSelector } from 'src/hooks/redux';
import { useHistory } from 'react-router';
import { LIST_CATEGORY } from 'src/constants/pages';

const initialValues: ICategoryRequest = {
    name: '',
    description: '',
    imageFile: undefined,
}

type Props = {
    initialForm?: ICategoryRequest;
}

const FormCategory: React.FC<Props> = ({ initialForm }) => {
    const history = useHistory();
    const dispatch = useDispatch();
    const { createResult, isLoading } = useAppSelector(state => state.category);

    const handleCancle = () => {
        history.push(LIST_CATEGORY);
    }

    if (isLoading) {
        NProgress.start();
    } else {
        NProgress.done();
    }

    useEffect(() => {
        if (createResult && createResult?.isSuccess) {
            NotificationManager.success(
                initialForm ? `Updated Successful category ${createResult.category?.name}` : `Created Successful category ${createResult.category?.name}`,
                initialForm ? 'Update Successful' : 'Create Successful',
                2000,
            );

            history.push(LIST_CATEGORY);
        }
        if (createResult && !createResult?.isSuccess) {
            NotificationManager.error(
                `Something went wrong!!!`,
                'Save failed',
                2000,
            );
        }

        return () => {
            dispatch(cleanUp());
        }
    }, [createResult]);

    return (
        <Formik
            initialValues={initialForm || initialValues}
            onSubmit={(values) => {
                dispatch(createCategory(values));
            }}
        >
            {(actions) => (
                <Form className='intro-y box p-5'>
                    <TextField name='name' label='Name' placeholder='Category Name' />
                    <TextField name='description' label='Description' placeholder='Description' />
                    <FileUpload label="Image" name="imageFile" />

                    <div className="text-right mt-5">
                        <button onClick={handleCancle} type="button" className="button w-24 border text-gray-700 mr-1">
                            Cancel
                        </button>

                        <button type="submit" className="button w-24 bg-theme-1 text-white"
                            disabled={isLoading}>
                            {initialForm ? 'Update' : 'Create'}
                            {(isLoading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                        </button>
                    </div>
                </Form>
            )}
        </Formik>
    );
};

export default FormCategory;