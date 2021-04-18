import React, { useEffect } from 'react';

import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import ISelectOption from 'src/interfaces/ISelectOption';
import { getCatgories } from 'src/redux/ducks/category';
import FormProduct from '../Form';

const CreateProduct = () => {
    const dispatch = useAppDispatch();
    const { categories, isLoading } = useAppSelector(state => state.category);

    useEffect(() => {
        if (categories.length < 1) {
            dispatch(getCatgories());
        }
    }, []);

    const categoryOptions: ISelectOption[] = categories.map(category => ({
        label: category.name,
        value: category.categoryId
    }));

    return isLoading ? (
        <div>Loading ... </div>
    ) : (
        <>
            <div className="intro-y flex items-center mt-8">
                <h2 className="text-lg font-medium mr-auto">
                    Create Product
                </h2>
            </div>
            <div className="grid grid-cols-12 gap-6 mt-5">
                <div className="intro-y col-span-12">
                    <FormProduct categoryOptions={categoryOptions} />
                </div>
            </div>
        </>
    );
};

export default CreateProduct;
