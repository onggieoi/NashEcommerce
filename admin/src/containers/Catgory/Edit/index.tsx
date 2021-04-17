import React from 'react';
import { useHistory, useParams } from 'react-router-dom';
import FormCategory from '../Form';

const EditCategory = () => {
    const { id } = useParams<{ id: string }>();
    console.log(id);

    return (
        <>
            <div className="intro-y flex items-center mt-8">
                <h2 className="text-lg font-medium mr-auto">
                    Edit Category
                </h2>
            </div>
            <div className="grid grid-cols-12 gap-6 mt-5">
                <div className="intro-y col-span-12">
                    <FormCategory />
                </div>
            </div>
        </>
    );
};

export default EditCategory;
