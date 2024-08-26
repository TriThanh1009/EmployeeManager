export interface WorkhourEditRequest {
    id: number,
    employeesID: string,
    lbdid: string,
    day: number,
    month: number,
    year: number,
    hourCheckin: number,
    minuteCheckin: number,
    hourCheckout: number,
    minuteCheckout: number
}

