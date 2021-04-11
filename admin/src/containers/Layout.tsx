import React from 'react';
import { Activity, Box, ChevronDown, Home } from 'react-feather';
import { Link } from 'react-router-dom';
import Header from 'src/components/Header';

const Layout = ({ children }) => {
  return (
    <div className='flex'>
      <nav className="side-nav">
        <a href="" className="intro-x flex items-center pl-5 pt-4">
          <img alt="Admin" className="w-6" src="/images/logo.svg" />
          <span className="hidden xl:block text-white text-lg ml-3"> Mid<span className="font-medium">one</span> </span>
        </a>
        <div className="side-nav__devider my-6"></div>
        <ul>
          <li>
            <a href="index.html" className="side-menu side-menu--active">
              <div className="side-menu__icon"> <Home /> </div>
              <div className="side-menu__title"> Dashboard </div>
            </a>
          </li>
          <li>
            <a href="" className="side-menu">
              <div className="side-menu__icon"> <Box /> </div>
              <div className="side-menu__title">
                Menu Layout
                <ChevronDown className="side-menu__sub-icon"></ChevronDown>
              </div>
            </a>
            <ul className="">
              <li>
                <a href="index.html" className="side-menu">
                  <div className="side-menu__icon"> <Activity /> </div>
                  <div className="side-menu__title"> Side Menu </div>
                </a>
              </li>
              <li>
                <a href="simple-menu-dashboard.html" className="side-menu">
                  <div className="side-menu__icon"> <Activity /> </div>
                  <div className="side-menu__title"> Simple Menu </div>
                </a>
              </li>
              <li>
                <a href="top-menu-dashboard.html" className="side-menu">
                  <div className="side-menu__icon"> <Activity /> </div>
                  <div className="side-menu__title"> Top Menu </div>
                </a>
              </li>
            </ul>
          </li>
          <li className="side-nav__devider my-6"></li>
        </ul>
      </nav>

      <div className='content'>
        <Header />
        {children}
      </div>
    </div>
  )
};

export default Layout;
{/* <>
        //   <div className='className'>Layout</div>
    //   <div>
          //     <Link to="/authentication/login" className="nav-link text-dark">
            //       Login
    //     </Link>
    //   </div>
    //   {children}
    // </> */}