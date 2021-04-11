import React from 'react';
import { Link } from 'react-router-dom';

const Layout = ({ children }) => {
  return (
    <div className='flex'>
      <nav className="side-nav">
        <a href="" className="intro-x flex items-center pl-5 pt-4">
          <img alt="Midone Tailwind HTML Admin Template" className="w-6" src="dist/images/logo.svg" />
          <span className="hidden xl:block text-white text-lg ml-3"> Mid<span className="font-medium">one</span> </span>
        </a>
        <div className="side-nav__devider my-6"></div>
        <ul>
          <li>
            <a href="index.html" className="side-menu side-menu--active">
              <div className="side-menu__icon"> <i data-feather="home"></i> </div>
              <div className="side-menu__title"> Dashboard </div>
            </a>
          </li>
          <li>
            <a href="javascript:;" className="side-menu">
              <div className="side-menu__icon"> <i data-feather="box"></i> </div>
              <div className="side-menu__title"> Menu Layout <i data-feather="chevron-down" className="side-menu__sub-icon"></i> </div>
            </a>
            <ul className="">
              <li>
                <a href="index.html" className="side-menu">
                  <div className="side-menu__icon"> <i data-feather="activity"></i> </div>
                  <div className="side-menu__title"> Side Menu </div>
                </a>
              </li>
              <li>
                <a href="simple-menu-dashboard.html" className="side-menu">
                  <div className="side-menu__icon"> <i data-feather="activity"></i> </div>
                  <div className="side-menu__title"> Simple Menu </div>
                </a>
              </li>
              <li>
                <a href="top-menu-dashboard.html" className="side-menu">
                  <div className="side-menu__icon"> <i data-feather="activity"></i> </div>
                  <div className="side-menu__title"> Top Menu </div>
                </a>
              </li>
            </ul>
          </li>
          <li className="side-nav__devider my-6"></li>
        </ul>
      </nav>

      <div className='content'>
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