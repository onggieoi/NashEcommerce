import React from 'react';
import { Calendar, } from 'react-feather';

const Chart = () => {

    return (
        <div className="col-span-12 mt-8">
            <div className="intro-y block sm:flex items-center h-10">
                <h2 className="text-lg font-medium truncate mr-5">Sales Report</h2>
                <div className="sm:ml-auto mt-3 sm:mt-0 relative text-gray-700">
                    <Calendar className="w-4 h-4 z-10 absolute my-auto inset-y-0 ml-3 left-0" />
                    <input type="text" data-daterange="true" className="datepicker input w-full sm:w-56 box pl-10" />
                </div>
            </div>
            <div className="intro-y box p-5 mt-12 sm:mt-5">

                <div className="flex flex-col xl:flex-row xl:items-center">
                    <div className="flex">
                        <div>
                            <div className="text-theme-20 text-lg xl:text-xl font-bold">$15,000</div>
                            <div className="text-gray-600">This Month</div>
                        </div>
                        <div className="w-px h-12 border border-r border-dashed border-gray-300 mx-4 xl:mx-6"></div>
                        <div>
                            <div className="text-gray-600 text-lg xl:text-xl font-medium">$10,000</div>
                            <div className="text-gray-600">Last Month</div>
                        </div>
                    </div>
                </div>

                <div className="report-chart">
                    {/* <canvas id="report-line-chart" height="160" className="mt-6"></canvas> */}
                </div>

            </div>
        </div>
    );
};

export default Chart;