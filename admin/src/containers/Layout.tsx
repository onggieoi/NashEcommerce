import React from 'react';
import { Link } from 'react-router-dom';

const Layout = ({ children }) => {
  return (
    <>
      <div className='class'>Layout</div>
      <div>
        <Link to="/authentication/login" className="nav-link text-dark">
          Login
        </Link>
      </div>
      {children}
    </>
  )
};

export default Layout;