import React from 'react';
import Transaction, { ITransaction } from 'src/components/Transaction';

const transactions: ITransaction[] = [
    { id: 1, name: 'Some guy 1', image: '/images/profile-14.jpg', createAt: '6 August 2021', price: 23 },
    { id: 2, name: 'Some guy 2', image: '/images/profile-10.jpg', createAt: '21 July 2020', price: 23 },
    { id: 3, name: 'Some guy 3', image: '/images/profile-15.jpg', createAt: '5 January 2021', price: 23 },
    { id: 4, name: 'Some guy 4', image: '/images/profile-12.jpg', createAt: '26 August 2022', price: 23 },
    { id: 5, name: 'Some guy 5', image: '/images/profile-6.jpg', createAt: '16 August 2022', price: 23 },
    { id: 6, name: 'Some guy 6', image: '/images/profile-14.jpg', createAt: '17 August 2022', price: 23 },
];

const Transactions = () => {

    return (
        <div className="col-span-12  mt-3 xxl:mt-8" >
            <div className="intro-x flex items-center h-10">
                <h2 className="text-lg font-medium truncate mr-5">Transactions</h2>
            </div>
            <div className="mt-5">
                {
                    transactions.map(transaction => (
                        <Transaction key={transaction.id} transaction={transaction} />
                    ))
                }
                <a href="" className="intro-x w-full block text-center rounded-md py-3 border border-dotted border-theme-15 text-theme-16">View More</a>
            </div>
        </div>
    );
};

export default Transactions;