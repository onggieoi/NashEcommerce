import React from 'react';
import { Link } from 'react-router-dom';
import { DASHBOARD } from 'src/constants/pages';

const NotFound = () => {
  return (
    <div className="container">
      <div className="error-page flex flex-col lg:flex-row items-center justify-center h-screen text-center lg:text-left">
        <div className="-intro-x lg:mr-20">
          <img alt="Midone Tailwind HTML Admin Template" className="h-48 lg:h-auto" src="/images/error-illustration.svg" />
        </div>
        <div className="text-white mt-10 lg:mt-0">
          <div className="intro-x text-6xl font-medium">404</div>
          <div className="intro-x text-xl lg:text-3xl font-medium">Oops. This page has gone missing.</div>
          <div className="intro-x text-lg mt-3 mb-5">You may have mistyped the address or the page may have moved.</div>
          <Link to={DASHBOARD} className="intro-x border border-white p-3">Back to Dashboard</Link>
        </div>
      </div>
    </div>
  )
};

export default NotFound;