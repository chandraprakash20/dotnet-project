import { inquiryData } from "./inquiryData";

export interface inquiryListResponse {
    result: string;
    message: string;
    data: inquiryData[];
}