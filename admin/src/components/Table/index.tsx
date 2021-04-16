import React from 'react';
import Paging from './Paging';

type Props = {
    ColumnsName: string[];
    children: React.ReactNode;
};

const Table: React.FC<Props> = ({ ColumnsName, children }) => {

    return (
        <>
            <table className="table table-report -mt-2">
                <thead>
                    <tr>
                        {
                            ColumnsName.map((colName) => (
                                <th key={colName} className="text-center whitespace-no-wrap">{colName}</th>
                            ))
                        }
                    </tr>
                </thead>

                <tbody>
                    {children}
                </tbody>
            </table>

            <Paging />
        </>
    );
};

export default Table;
