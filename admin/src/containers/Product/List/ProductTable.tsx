import React, { useEffect } from 'react';
import { CheckSquare, Trash2 } from 'react-feather';
import { NotificationManager } from 'react-notifications';
import { Link } from 'react-router-dom';

import Table from 'src/components/Table';
import { toEditProductPage } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import IProduct from 'src/interfaces/IProduct';
import { cleanUp, deleteProduct, getProducts } from 'src/redux/ducks/product';
import formatDateTime from 'src/utils/formatDateTime';

type Props = {
    products: IProduct[];
};

const ProductTable: React.FC<Props> = ({ products }) => {
    const { productResult, isLoading } = useAppSelector(state => state.product);
    const dispatch = useAppDispatch();

    const handleDeleteProduct = (e, id: number) => {
        e.preventDefault();
        dispatch(deleteProduct(id.toString()));
    };

    useEffect(() => {
        if (productResult && productResult.isSuccess) {
            NotificationManager.success(
                `Deleted Successful product ${productResult.product?.productId}`,
                'Deleted Successful',
                2000,
            );
        }

        if (productResult && !productResult.isSuccess) {
            NotificationManager.error(
                `Something went wrong!!!`,
                'Delete failed',
                2000,
            );
        }

        return () => {
            dispatch(cleanUp());
            dispatch(getProducts());
        }
    }, [productResult]);

    return isLoading ? (
        <div>Loading...</div>
    ) : (
        <Table ColumnsName={['IMAGE', 'NAME', 'PRICE', 'RATED', 'DESCRIPTION', 'CATEGORY', 'UPDATE AT', 'CREATE AT']} >
            {
                products.map((product) => (
                    <tr className="intro-x" key={product.productId}>
                        <td className="w-40">
                            <div className="flex justify-center">
                                <div className="w-10 h-10 image-fit zoom-in">
                                    <img alt="images" className="tooltip rounded-full"
                                        src={product.image || '/images/profile-6.jpg'}
                                        title="Uploaded at 17 July 2021" />
                                </div>
                            </div>
                        </td>
                        <td className='text-center'>
                            <a className="font-medium whitespace-no-wrap cursor-pointer">{product.name}</a>
                            <div className="text-gray-600 text-xs whitespace-no-wrap">Photography</div>
                        </td>
                        <td className="text-center">
                            {product.price}
                        </td>
                        <td className="text-center">
                            {product.rated}
                        </td>
                        <td className="text-center">
                            {product.description}
                        </td>
                        <td className="text-center">
                            {product.categoryName}
                        </td>
                        <td className="text-center">
                            {formatDateTime(product.updatedAt)}
                        </td>
                        <td className="text-center">
                            {formatDateTime(product.createdAt)}
                        </td>
                        <td className="table-report__action w-56">
                            <div className="flex justify-center items-center">
                                <Link to={toEditProductPage(product.productId)}
                                    className="flex items-center mr-3">
                                    <CheckSquare className="w-4 h-4 mr-1" />
                                    Edit
                                </Link>

                                <a onClick={e => handleDeleteProduct(e, product.productId)}
                                    className="flex items-center text-theme-6 cursor-pointer">
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

export default ProductTable;