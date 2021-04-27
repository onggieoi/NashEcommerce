export default (date: string): string => 
{
    const dateUtc = new Date(date).toUTCString();
    
    // return new Date(dateUtc).toLocaleString('en-US',{
    //     year: "numeric",
    //     month: "2-digit",
    //     day: "numeric",
    //     hour: "2-digit",
    //     // timeZone: 'Asia/Ho_Chi_Minh',
    // });

    return dateUtc.split(',')[1].replace('GMT', '');
}
