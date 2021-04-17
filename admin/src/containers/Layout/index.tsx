import React from 'react';
import { NotificationContainer } from 'react-notifications';

import SideBar from './SideBar';
import Header from './Header'

const Layout = ({ children }) => {

  return (
    <div className='flex'>
      <NotificationContainer />
      <SideBar />
      <div className='content'>
        <Header />
        {children}
      </div>
    </div>
  )
};

export default Layout;
