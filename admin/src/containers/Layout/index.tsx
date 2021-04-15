import React from 'react';
import SideBar from './SideBar';
import Header from './Header'

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
