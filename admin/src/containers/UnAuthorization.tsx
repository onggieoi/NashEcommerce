import React from 'react';
import { useAppDispatch } from 'src/hooks/redux';
import { logout } from 'src/redux/ducks/auth';

const UnAuthorization = () => {
    const dispatch = useAppDispatch();

    const handleLogout = () => {
        dispatch(logout());
    };

    return (
        <div className="container">
            <div className="error-page flex flex-col lg:flex-row items-center justify-center h-screen text-center lg:text-left">
                <div className="-intro-x lg:mr-20">
                    <img alt="Midone Tailwind HTML Admin Template" className="h-48 lg:h-auto" src="/images/error-illustration.svg" />
                </div>
                <div className="text-white mt-10 lg:mt-0">
                    <div className="intro-x text-6xl font-medium">401</div>
                    <div className="intro-x text-xl lg:text-3xl font-medium">Oops. Access Dinied.</div>
                    <button onClick={handleLogout} className="intro-x button button--lg border border-white mt-10">
                        Logout
                    </button>
                </div>
            </div>
        </div>
    )
};

export default UnAuthorization;