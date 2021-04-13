import React, { useState } from 'react';
import { ChevronRight, Edit, HelpCircle, Lock, ToggleRight, User } from 'react-feather';

const Header = () => {
    const [showDropDown, setShow] = useState(false);

    const dropDown = (e) => {
        setShow(true);
    };

    const handleBlur = (e) => {
        setShow(false);
    }

    const dropDownBoxStyle = () => {
        if (showDropDown) return 'dropdown-box mt-10 absolute w-56 top-0 right-0 z-20 show';
        return 'dropdown-box mt-10 absolute w-56 top-0 right-0 z-20';
    };

    return (
        <>
            <div className="top-bar">

                <div className="-intro-x breadcrumb mr-auto hidden sm:flex">
                    <a href="" className="">Application</a>
                    <ChevronRight className="breadcrumb__icon" />
                    <a href="" className="breadcrumb--active">Dashboard</a>
                </div>

                <div className="intro-x dropdown w-8 h-8 relative">
                    <div onFocus={dropDown} onBlur={handleBlur} tabIndex={0}
                        className="dropdown-toggle w-8 h-8 rounded-full overflow-hidden shadow-lg image-fit zoom-in">
                        <img alt="Admin Name" src="/images/profile-12.jpg" />
                    </div>
                    <div className={dropDownBoxStyle()} >
                        <div className="dropdown-box__content bg-theme-38 text-white">
                            <div className="p-4 border-b border-theme-40">
                                <div className="font-medium">Angelina Jolie</div>
                                <div className="text-xs text-theme-41">Software Engineer</div>
                            </div>
                            <div className="p-2">
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <User className="w-4 h-4 mr-2"></User>
                                    Profile
                                </a>
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <Edit className="w-4 h-4 mr-2"></Edit>
                                    Add Account
                                </a>
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <Lock className="w-4 h-4 mr-2"></Lock>
                                    Reset Password
                                </a>
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <HelpCircle className="w-4 h-4 mr-2"></HelpCircle>
                                    Help
                                </a>
                            </div>
                            <div className="p-2 border-t border-theme-40">
                                <a href="" className="flex items-center block p-2 transition duration-300 ease-in-out hover:bg-theme-1 rounded-md">
                                    <ToggleRight className="w-4 h-4 mr-2"></ToggleRight>
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