import React from 'react';
import { ChevronDown, ChevronUp, CreditCard, Monitor, ShoppingCart, User } from 'react-feather';

const Reports = () => {

    return (
        <div className="grid grid-cols-12 gap-6 mt-5">

            <div className="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                <div className="report-box zoom-in">
                    <div className="box p-5">
                        <div className="flex">
                            <ShoppingCart className="report-box__icon text-theme-10"></ShoppingCart>
                            <div className="ml-auto">
                                <div className="report-box__indicator bg-theme-9 cursor-pointer" title="33% Higher than last month">
                                    33% <ChevronUp className="w-4 h-4" />
                                </div>
                            </div>
                        </div>
                        <div className="text-3xl font-bold leading-8 mt-6">4.510</div>
                        <div className="text-base text-gray-600 mt-1">Item Sales</div>
                    </div>
                </div>
            </div>

            <div className="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                <div className="report-box zoom-in">
                    <div className="box p-5">
                        <div className="flex">
                            <CreditCard className="report-box__icon text-theme-11"></CreditCard>
                            <div className="ml-auto">
                                <div className="report-box__indicator bg-theme-6 cursor-pointer" title="2% Lower than last month">
                                    2% <ChevronDown className="w-4 h-4"></ChevronDown>
                                </div>
                            </div>
                        </div>
                        <div className="text-3xl font-bold leading-8 mt-6">3.521</div>
                        <div className="text-base text-gray-600 mt-1">New Orders</div>
                    </div>
                </div>
            </div>

            <div className="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                <div className="report-box zoom-in">
                    <div className="box p-5">
                        <div className="flex">
                            <Monitor className="report-box__icon text-theme-12"></Monitor>
                            <div className="ml-auto">
                                <div className="report-box__indicator bg-theme-9 cursor-pointer" title="12% Higher than last month">
                                    12% <ChevronUp className="w-4 h-4"></ChevronUp>
                                </div>
                            </div>
                        </div>
                        <div className="text-3xl font-bold leading-8 mt-6">2.145</div>
                        <div className="text-base text-gray-600 mt-1">Total Products</div>
                    </div>
                </div>
            </div>

            <div className="col-span-12 sm:col-span-6 xl:col-span-3 intro-y">
                <div className="report-box zoom-in">
                    <div className="box p-5">
                        <div className="flex">
                            <User className="report-box__icon text-theme-9"></User>
                            <div className="ml-auto">
                                <div className="report-box__indicator bg-theme-9 cursor-pointer" title="22% Higher than last month">
                                    22% <ChevronUp className="w-4 h-4"></ChevronUp>
                                </div>
                            </div>
                        </div>
                        <div className="text-3xl font-bold leading-8 mt-6">152.000</div>
                        <div className="text-base text-gray-600 mt-1">Unique Visitor</div>
                    </div>
                </div>
            </div>

        </div>
    );
};

export default Reports;