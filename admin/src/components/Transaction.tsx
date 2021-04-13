import React from 'react';

interface IProps {
    transaction: ITransaction;
}

export interface ITransaction {
    id: number;
    name: string;
    image: string;
    createAt: string;
    price: number;
}

const Transaction: React.FC<IProps> = ({
    transaction
}) => {

    return (
        <div className="intro-x">
            <div className="box px-5 py-3 mb-3 flex items-center zoom-in">
                <div className="w-10 h-10 flex-none image-fit rounded-full overflow-hidden">
                    <img alt="Admin" src={transaction.image} />
                </div>
                <div className="ml-4 mr-auto">
                    <div className="font-medium">{transaction.name}</div>
                    <div className="text-gray-600 text-xs">{transaction.createAt}</div>
                </div>
                <div className="text-theme-9">+ ${transaction.price}</div>
            </div>
        </div>
    );
};

export default Transaction;
