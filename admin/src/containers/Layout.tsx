import React from 'react';
import { Link } from 'react-router-dom';
import Header from 'src/components/Header';
import SideBar from 'src/components/SideBar';

const Layout = ({ children }) => {
  return (
    <div className='flex'>
      <SideBar />
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