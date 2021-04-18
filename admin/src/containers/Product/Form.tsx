import React, { useEffect } from 'react';
import { Form, Formik } from 'formik';
import { NotificationManager } from 'react-notifications';
import NProgress from 'nprogress';

import TextField from 'src/components/Form/TextField';
import FileUpload from 'src/components/Form/FileUpload';
import { useDispatch } from 'react-redux';
import { cleanUp, createProduct, updateProduct } from 'src/redux/ducks/product';
import { useAppSelector } from 'src/hooks/redux';
import { useHistory } from 'react-router';
import { LIST_PRODUCT } from 'src/constants/pages';
import IProductRequest from 'src/interfaces/IProductRequest';
import UnitField from 'src/components/Form/UnitField';
import SelectField from 'src/components/Form/SelectField';
import ISelectOption from 'src/interfaces/ISelectOption';

const initialValues: IProductRequest = {
    name: '',
    description: '',
    imageFile: undefined,
    price: 0,
    categoryId: 0,
}

type Props = {
    initialForm?: IProductRequest;
    categoryOptions: ISelectOption[];
}

const FormProduct: React.FC<Props> = ({ initialForm, categoryOptions }) => {
    const history = useHistory();
    const dispatch = useDispatch();
    const { productResult, isLoading } = useAppSelector(state => state.product);

    const handleCancle = () => {
        history.push(LIST_PRODUCT);
    }

    if (isLoading) {
        NProgress.start();
    } else {
        NProgress.done();
    }

    if (initialForm) {
        initialForm = {
            ...initialForm,
            categoryId: categoryOptions.find(option => option.value === initialForm?.categoryId) as any
        };
    }

    useEffect(() => {
        if (productResult && productResult?.isSuccess) {
            NotificationManager.success(
                initialForm
                    ? `Updated Successful product ${productResult.product?.name}`
                    : `Created Successful product ${productResult.product?.name}`,
                initialForm ? 'Update Successful' : 'Create Successful',
                2000,
            );

            history.push(LIST_PRODUCT);
        }
        if (productResult && !productResult?.isSuccess) {
            NotificationManager.error(
                `Something went wrong!!!`,
                'Save failed',
                2000,
            );
        }

        return () => {
            console.log('cleanup');
            dispatch(cleanUp());
        }
    }, [productResult]);

    return (
        <Formik
            initialValues={initialForm || initialValues}
            onSubmit={(values) => {
                values.categoryId = values.categoryId?.['value'];

                if (values.productId) {
                    dispatch(updateProduct(values));
                } else {
                    dispatch(createProduct(values));
                }
            }}
        >
            {(actions) => (
                <Form className='intro-y box p-5'>
                    <TextField name='name' label='Name' placeholder='Product Name' />
                    <TextField name='description' label='Description' placeholder='Description' />
                    <UnitField type='number' name='price' label='Price' unit='$' />
                    <SelectField name='categoryId' label='Category' isMulti={false} data={categoryOptions} />
                    <FileUpload label="Image" name="imageFile" image={actions.values.image} />

                    <div className="text-right mt-5">
                        <button onClick={handleCancle} type="button" className="button w-24 border text-gray-700 mr-1">
                            Cancel
                        </button>

                        <button className="button w-24 bg-theme-1 text-white"
                            type="submit" disabled={isLoading}>
                            {initialForm ? 'Update' : 'Create'}
                            {(isLoading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                        </button>
                    </div>
                </Form>
            )}
        </Formik>
    );
};

export default FormProduct;