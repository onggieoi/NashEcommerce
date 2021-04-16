import React from 'react';
import { Link, useLocation } from 'react-router-dom';

type Props = {
    path: string;
    children: React.ReactNode;
}

const NavItem: React.FC<Props> = ({ path, children }) => {
    const { pathname } = useLocation();

    const styleNav = () =>
        path.split('/')[1] === pathname.split('/')[1] ? 'side-menu  side-menu--active' : 'side-menu';

    return (
        <li>
            <Link to={path} className={styleNav()}>
                {children}
            </Link>
        </li>
    );
};

export default NavItem;