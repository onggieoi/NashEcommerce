import React, { useEffect } from 'react';
import { CheckSquare, Trash2 } from 'react-feather';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';

import Table from 'src/components/Table';
import { editPage, LIST_CATEGORY } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import ICategory from 'src/interfaces/ICategory';
import { cleanUp, deleteCategory, getCatgories } from 'src/redux/ducks/category';

type Props = {
    categories: ICategory[];
};

const CategoryTable: React.FC<Props> = ({ categories }) => {
    const { createResult } = useAppSelector(state => state.category);
    const dispatch = useAppDispatch();

    const handleDeleteCategory = (e, id: number) => {
        e.preventDefault();
        dispatch(deleteCategory(id.toString()));
    };

    useEffect(() => {
        if (createResult && createResult.isSuccess) {
            NotificationManager.success(
                `Deleted Successful category ${createResult.category?.categoryId}`,
                'Deleted Successful',
                2000,
            );
        }

        if (createResult && !createResult.isSuccess) {
            NotificationManager.error(
                `Something went wrong!!!`,
                'Delete failed',
                2000,
            );
        }

        return () => {
            dispatch(cleanUp());
            dispatch(getCatgories());
        }
    }, [createResult]);

    return (
        <Table ColumnsName={['IMAGE', 'NAME', 'DESCRIPTION',]} >
            {
                categories.map((category) => (
                    <tr className="intro-x" key={category.categoryId}>
                        <td className="w-40">
                            <div className="flex justify-center">
                                <div className="w-10 h-10 image-fit zoom-in">
                                    <img alt="images" className="tooltip rounded-full"
                                        src={category.image || '/images/profile-6.jpg'}
                                        title="Uploaded at 17 July 2021" />
                                </div>
                            </div>
                        </td>
                        <td className='text-center'>
                            <a href="" className="font-medium whitespace-no-wrap">{category.name}</a>
                            <div className="text-gray-600 text-xs whitespace-no-wrap">Photography</div>
                        </td>
                        <td className="text-center">
                            {category.description}
                        </td>
                        {/* <td className="">
                            <div className="flex justify-center text-theme-6">
                                <CheckSquare className="w-4 h-4 mr-2" />
                            Inactive
                            </div>
                        </td> */}
                        <td className="table-report__action w-56">
                            <div className="flex justify-center items-center">
                                <Link to={editPage(category.categoryId)} className="flex items-center mr-3">
                                    <CheckSquare className="w-4 h-4 mr-1" />
                                    Edit
                                </Link>

                                <a onClick={(e) => handleDeleteCategory(e, category.categoryId)} className="flex items-center text-theme-6 cursor-pointer">
                                    <Trash2 className="w-4 h-4 mr-1" />
                                    Delete
                                </a>
                            </div>
                        </td>
                    </tr>
                ))
            }
        </Table>
    );
};

export default CategoryTable;