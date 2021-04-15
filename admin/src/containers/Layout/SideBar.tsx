import React, { useState } from 'react';
import { Activity, Box, ChevronDown, Home } from 'react-feather';

const SideBar = () => {
    const [navDropDown, setDropdown] = useState(false);

    const handleDropDown = (e) => {
        e.preventDefault();
        setDropdown(!navDropDown);
    }

    const styleNavDropDown = () =>
        navDropDown ? {
            sideMenu: 'side-menu side-menu--open',
            subMenu: 'side-menu__sub-open',
        } : {
            sideMenu: 'side-menu',
            subMenu: '',
        };


    return (
        <nav className="side-nav">
            <a href="" className="intro-x flex items-center pl-5 pt-4">
                <img alt="Admin" className="w-6" src="/images/logo.svg" />
                <span className="hidden xl:block text-white text-lg ml-3"> Mid<span className="font-medium">one</span> </span>
            </a>
            <div className="side-nav__devider my-6"></div>
            <ul>
                <li>
                    <a href="" className="side-menu side-menu--active">
                        <div className="side-menu__icon"> <Home /> </div>
                        <div className="side-menu__title"> Dashboard </div>
                    </a>
                </li>
                <li>
                    <a href='' onClick={handleDropDown} className={styleNavDropDown().sideMenu}>
                        <div className="side-menu__icon"> <Box /> </div>
                        <div className="side-menu__title">
                            Menu Layout <ChevronDown className="side-menu__sub-icon"></ChevronDown>
                        </div>
                    </a>
                    <ul className={styleNavDropDown().subMenu}>
                        <li>
                            <a href="" className="side-menu">
                                <div className="side-menu__icon"> <Activity /> </div>
                                <div className="side-menu__title"> Sub Menu </div>
                            </a>
                        </li>
                        <li>
                            <a href="" className="side-menu">
                                <div className="side-menu__icon"> <Activity /> </div>
                                <div className="side-menu__title"> Sub Menu </div>
                            </a>
                        </li>
                        <li>
                            <a href="" className="side-menu">
                                <div className="side-menu__icon"> <Activity /> </div>
                                <div className="side-menu__title"> Sub Menu </div>
                            </a>
                        </li>
                    </ul>
                </li>
                <li className="side-nav__devider my-6"></li>
            </ul>
        </nav>
    );
};

export default SideBar;