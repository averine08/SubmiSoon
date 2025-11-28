// Format: 30 Aug 2025
export function formatDateOnly(dateString: string) {
    return new Intl.DateTimeFormat("en-GB", {
        day: "2-digit",
        month: "short",
        year: "numeric",
        timeZone: "Asia/Jakarta", 
    }).format(new Date(dateString));
}

// Format: 30 Aug 2025, 23:59 PM (GMT+7)
export function formatEndDateWithTime(dateString: string) {
    const date = new Date(dateString);

    const datePart = new Intl.DateTimeFormat("en-GB", {
        day: "2-digit",
        month: "short",
        year: "numeric",
        timeZone: "Asia/Jakarta",
    }).format(date);

    const timePart = new Intl.DateTimeFormat("en-GB", {
        hour: "2-digit",
        minute: "2-digit",
        hour12: true,
        timeZone: "Asia/Jakarta",
    }).format(date).toUpperCase();

    return `${datePart}, ${timePart} (GMT+7)`;
    
}