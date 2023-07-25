import { bookingData } from "./bookingData";
export interface bookingDetailResponse {
    result: string;
    message: string;
    data: bookingData;
}