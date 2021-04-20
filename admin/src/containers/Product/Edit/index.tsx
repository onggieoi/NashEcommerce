import React, { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Loading from 'src/components/Loading';

import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import ISelectOption from 'src/interfaces/ISelectOption';
import { getCatgories } from 'src/redux/ducks/category';
import { getProduct } from 'src/redux/ducks/product';
import FormProduct from '../Form';

const EditProduct = () => {
    const { id } = useParams<{ id: string }>();
    const dispatch = useAppDispatch();
    const { product, isLoading } = useAppSelector(state => state.product);
    const { categories, isLoading: categoryLoading } = useAppSelector(state => state.category);

    useEffect(() => {
        dispatch(getProduct(id));

        if (categories.length < 1) {
            dispatch(getCatgories());
        }
    }, [id]);

    const categoryOptions: ISelectOption[] = categories.map(category => ({
        label: category.name,
        value: category.categoryId
    }));

    return (categories && product) ? (
        <>
            <div className="intro-y flex items-center mt-8">
                <h2 className="text-lg font-medium mr-auto">
                    Edit Product
                </h2>
            </div>
            <div className="grid grid-cols-12 gap-6 mt-5">
                <div className="intro-y col-span-12">
                    <FormProduct initialForm={product} categoryOptions={categoryOptions} />
                </div>
            </div>
        </>
    ) : (<Loading />);
};

export default EditProduct;
