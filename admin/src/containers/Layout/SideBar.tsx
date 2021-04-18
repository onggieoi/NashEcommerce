import React from 'react';
import { Activity, Home, Users } from 'react-feather';
import { Link } from 'react-router-dom';

import NavItem from 'src/components/NavItem';

import { CATEGORY, CUSTOMER, DASHBOARD, PRODUCT } from 'src/constants/pages';

const SideBar = () => {
    return (
        <nav className="side-nav">
            <Link to={DASHBOARD} className="intro-x flex items-center pl-5 pt-4">
                <img alt="Admin" className="w-6" src="/images/logo.svg" />
                <span className="hidden xl:block text-white text-lg ml-3"> Mid<span className="font-medium">one</span> </span>
            </Link>
            <div className="side-nav__devider my-6"></div>
            <ul>
                <NavItem path={DASHBOARD}>
                    <div className="side-menu__icon"> <Home /> </div>
                    <div className="side-menu__title"> Dashboard </div>
                </NavItem>

                <NavItem path={CATEGORY}>
                    <div className="side-menu__icon"> <Activity /> </div>
                    <div className="side-menu__title"> Categories </div>
                </NavItem>

                <NavItem path={PRODUCT}>
                    <div className="side-menu__icon"> <Activity /> </div>
                    <div className="side-menu__title"> Products </div>
                </NavItem>

                <NavItem path={CUSTOMER}>
                    <div className="side-menu__icon"> <Users /> </div>
                    <div className="side-menu__title"> Customers </div>
                </NavItem>

                <li className="side-nav__devider my-6"></li>
            </ul>
        </nav>
    );
};

export default SideBar;