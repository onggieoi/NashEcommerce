import React, { useEffect } from 'react';
import { Search } from 'react-feather';
import { Link } from 'react-router-dom';
import Loading from 'src/components/Loading';
import { CREATE_CATEGORY } from 'src/constants/pages';

import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { getCustomers } from 'src/redux/ducks/customer';
import CustomerTable from './CustomerTable';

const ListCustomer = () => {
    const dispatch = useAppDispatch();
    const { customers, isLoading } = useAppSelector(state => state.customer);

    useEffect(() => {
        dispatch(getCustomers());
    }, []);

    return isLoading ? (<Loading />) : (
        <>
            <h2 className="intro-y text-lg font-medium mt-10">
                Customers
            </h2>

            <div className="grid grid-cols-12 gap-6 mt-5">
                <div className="intro-y col-span-12 flex flex-wrap sm:flex-no-wrap items-center mt-2">
                    <button className="button text-white bg-theme-1 shadow-md mr-2">
                        <Link to={CREATE_CATEGORY}>
                            Add New Customer
                        </Link>
                    </button>

                    <div className="hidden md:block mx-auto text-gray-600">Showing 1 to 10 of 150 entries</div>

                    <div className="w-full sm:w-auto mt-3 sm:mt-0 sm:ml-auto md:ml-0">
                        <div className="w-56 relative text-gray-700">
                            <input type="text" className="input w-56 box pr-10 placeholder-theme-13" placeholder="Search..." />
                            <Search className="w-4 h-4 absolute my-auto inset-y-0 mr-3 right-0" />
                        </div>
                    </div>
                </div>

                <div className="intro-y col-span-12 overflow-auto lg:overflow-visible">
                    <CustomerTable customers={customers} />
                </div>
            </div>
        </>
    );
};

export default ListCustomer;