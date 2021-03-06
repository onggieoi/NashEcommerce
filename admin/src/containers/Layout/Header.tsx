import React, { useState } from 'react';
import { ChevronRight, Edit, HelpCircle, Lock, ToggleRight, User } from 'react-feather';
import { useLocation } from 'react-router';

import { CATEGORY, CUSTOMER, DASHBOARD, PRODUCT } from 'src/constants/pages';
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { logout } from 'src/redux/ducks/auth';

const Header = () => {
    const dispatch = useAppDispatch();
    const { pathname } = useLocation();
    const [showDropDown, setShow] = useState(false);
    const name = useAppSelector(state => state.auth.user.profile.name);

    const handleLogout = (e) => {
        e.preventDefault();

        dispatch(logout());
    }

    const dropDown = (e) => {
        setShow(!showDropDown);
    };

    const dropDownBoxStyle = () => {
        if (showDropDown) return 'dropdown-box mt-10 absolute w-56 top-0 right-0 z-20 show';
        return 'dropdown-box mt-10 absolute w-56 top-0 right-0 z-20';
    };

    const breadcrumbName = () => {
        switch (pathname) {
            case DASHBOARD:
                return 'Dashboard';

            case PRODUCT:
                return 'Product';

            case CATEGORY:
                return 'Category';

            case CUSTOMER:
                return 'Customer';

            default:
                return;
        }
    };

    return (
        <>
            <div className="top-bar">

                <div className="-intro-x breadcrumb mr-auto hidden sm:flex">
                    <a className="">Administrator</a>
                    <ChevronRight className="breadcrumb__icon" />
                    <a className="breadcrumb--active">{breadcrumbName()}</a>
                </div>

                <div className="intro-x dropdown w-8 h-8 relative">
                    <div onClick={dropDown}
                        className="dropdown-toggle w-8 h-8 rounded-full overflow-hidden shadow-lg image-fit zoom-in focus:outline-none">
                        <img alt={name} src="/images/profile-12.jpg" />
                    </div>
                    <div className={dropDownBoxStyle()} >
                        <div className="dropdown-box__content bg-theme-38 text-white">
                            <div className="p-4 border-b border-theme-40">
                                <div className="font-medium">{name}</div>
                                <div className="text-xs text-theme-41">Software Engineer</div>
                            </div>
                            <div className="p-2">
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <User className="w-4 h-4 mr-2" />
                                    Profile
                                </a>
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <Edit className="w-4 h-4 mr-2" />
                                    Add Account
                                </a>
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <Lock className="w-4 h-4 mr-2" />
                                    Reset Password
                                </a>
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <HelpCircle className="w-4 h-4 mr-2" />
                                    Help
                                </a>
                            </div>
                            <div className="p-2 border-t border-theme-40">
                                <a onClick={handleLogout} className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md cursor-pointer">
                                    <ToggleRight className="w-4 h-4 mr-2" />
                                    Logout
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </>
    );
};

export default Header;