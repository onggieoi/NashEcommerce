import React from 'react';
import { RefreshCcw, } from 'react-feather';
import { useSelector } from 'react-redux';
import Chart from './Chart';

import Reports from './Reports';
import Transactions from './Transactions';

const DashBoard = () => {
    return (
        <div className="grid grid-cols-12 gap-6">
            {/* Left side */}
            <div className="col-span-12 xxl:col-span-9 grid grid-cols-12 gap-6">
                <div className="col-span-12 mt-8">
                    <div className="intro-y flex items-center h-10">
                        <h2 className="text-lg font-medium truncate mr-5">General Report</h2>
                        <a href="" className="ml-auto flex text-theme-1">
                            <RefreshCcw className="w-4 h-4 mr-3" />Reload Data
                        </a>
                    </div>
                    <Reports />
                </div>
                <Chart />
            </div>

            {/* Right side */}
            <div className="col-span-12 xxl:col-span-3 xxl:border-l border-theme-5 -mb-10 pb-10">
                <div className="xxl:pl-6 grid grid-cols-12 gap-6">
                    <Transactions />
                </div>
            </div>
        </div>
    )
};

export default DashBoard;