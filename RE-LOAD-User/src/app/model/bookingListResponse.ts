import { bookingData } from "./bookingData";
export interface bookingListResponse {
    result: string;
    message: string;
    data: bookingData[];
}