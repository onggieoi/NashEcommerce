export default (date: string): string => new Date(date).toLocaleString('en',{
    year: "numeric",
    month: "2-digit",
    day: "numeric",
    hour: "2-digit",
    timeZone: 'Asia/Ho_Chi_Minh',
});
