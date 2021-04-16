import React, { useEffect } from 'react';
import {
    ChevronLeft, ChevronRight, ChevronsLeft, ChevronsRight, Search,
} from 'react-feather';
import { useDispatch } from 'react-redux';

import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { getCatgories } from 'src/redux/ducks/category';
import CategoryTable from './CategoryTable';

const Catgories = () => {
    const dispatch = useAppDispatch();
    const { categories, isLoading } = useAppSelector(state => state.category);

    useEffect(() => {
        dispatch(getCatgories());
    }, []);

    return isLoading ? (<div>Loading...</div>) : (
        <>
            <h2 className="intro-y text-lg font-medium mt-10">
                Categories
            </h2>

            <div className="grid grid-cols-12 gap-6 mt-5">
                <div className="intro-y col-span-12 flex flex-wrap sm:flex-no-wrap items-center mt-2">
                    <button className="button text-white bg-theme-1 shadow-md mr-2">Add New Category</button>

                    <div className="hidden md:block mx-auto text-gray-600">Showing 1 to 10 of 150 entries</div>

                    <div className="w-full sm:w-auto mt-3 sm:mt-0 sm:ml-auto md:ml-0">
                        <div className="w-56 relative text-gray-700">
                            <input type="text" className="input w-56 box pr-10 placeholder-theme-13" placeholder="Search..." />
                            <Search className="w-4 h-4 absolute my-auto inset-y-0 mr-3 right-0" />
                        </div>
                    </div>
                </div>

                <div className="intro-y col-span-12 overflow-auto lg:overflow-visible">
                    <CategoryTable categories={categories} />
                </div>
            </div>
        </>
    );
};

export default Catgories;