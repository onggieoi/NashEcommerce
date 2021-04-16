import React from 'react';
import { CheckSquare, Trash2 } from 'react-feather';

import Table from 'src/components/Table';
import IProduct from 'src/interfaces/IProduct';

type Props = {
    products: IProduct[];
};

const ProductTable: React.FC<Props> = ({ products }) => {
    return (
        <Table ColumnsName={['IMAGE', 'NAME', 'PRICE', 'RATED', 'DESCRIPTION', 'CATEGORY']} >
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
                            <a href="" className="font-medium whitespace-no-wrap">{product.name}</a>
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
                        <td className="table-report__action w-56">
                            <div className="flex justify-center items-center">
                                <a className="flex items-center mr-3">
                                    <CheckSquare className="w-4 h-4 mr-1" />
                                Edit
                            </a>

                                <a className="flex items-center text-theme-6">
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