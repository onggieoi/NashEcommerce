import React from 'react';
import { ChevronsLeft, ChevronLeft, ChevronRight, ChevronsRight } from 'react-feather';

const Paging = () => {

    return (
        <div className="intro-y col-span-12 flex flex-wrap sm:flex-row sm:flex-no-wrap items-center">
            <ul className="pagination">
                <li>
                    <a className="pagination__link" href=""> <ChevronsLeft className="w-4 h-4" />
                    </a>
                </li>
                <li>
                    <a className="pagination__link" href=""> <ChevronLeft className="w-4 h-4" />
                    </a>
                </li>
                <li> <a className="pagination__link" href="">1</a> </li>
                <li> <a className="pagination__link pagination__link--active" href="">2</a> </li>
                <li> <a className="pagination__link" href="">3</a> </li>
                <li>
                    <a className="pagination__link" href=""> <ChevronRight className="w-4 h-4" />
                    </a>
                </li>
                <li>
                    <a className="pagination__link" href=""> <ChevronsRight className="w-4 h-4" />
                    </a>
                </li>
            </ul>
            <select className="w-20 input box mt-3 sm:mt-0">
                <option>10</option>
                <option>25</option>
                <option>35</option>
                <option>50</option>
            </select>
        </div>
    );
};

export default Paging;