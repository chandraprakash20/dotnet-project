import { inquiryData } from "./inquiryData"; 

export interface inquiryDetailResponse {
    result: string;
    message: string;
    data: inquiryData;
}