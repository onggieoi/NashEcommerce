export default (date: string): string => 
{
    const utcDate = new Date(date).toLocaleString() + ' UTC';

    return new Date(Date.parse(utcDate)).toLocaleString('en-US', {
        year: "numeric",
        month: "2-digit",
        day: "numeric",
        hour: "2-digit",
    });
}
