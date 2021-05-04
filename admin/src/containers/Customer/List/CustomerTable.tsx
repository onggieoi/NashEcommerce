import React from 'react';
import { CheckSquare, Trash2 } from 'react-feather';

import Table from 'src/components/Table';
import ICustomer from 'src/interfaces/ICustomer';

type Props = {
    customers: ICustomer[];
};

const CustomerTable: React.FC<Props> = ({ customers }) => {
    return (
        <Table ColumnsName={['', 'USERNAME', 'EMAIL', 'PHONE',]} >
            {
                customers.map((customer) => (
                    <tr className="intro-x" key={customer.id}>
                        <td className="w-40">
                            <div className="flex justify-center">
                                <div className="w-10 h-10 image-fit zoom-in">
                                    <img alt="images" className="tooltip rounded-full"
                                        src={customer?.image || '/images/profile-6.jpg'}
                                        title="Uploaded at 17 July 2021" />
                                </div>
                            </div>
                        </td>
                        <td className='text-center'>
                            <a href="" className="font-medium whitespace-no-wrap">{customer.userName}</a>
                            <div className="text-gray-600 text-xs whitespace-no-wrap">Photography</div>
                        </td>
                        <td className="text-center">
                            {customer.email || 'unknown'}
                        </td>
                        <td className="text-center">
                            {customer.phoneNumber || 'unknown'}
                        </td>
                        <td className="table-report__action w-56">
                            <div className="flex justify-center items-center">
                                <a className="flex items-center mr-3 cursor-pointer">
                                    <CheckSquare className="w-4 h-4 mr-1" />
                                    Edit
                                </a>

                                <a className="flex items-center text-theme-6 cursor-pointer">
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

export default CustomerTable;