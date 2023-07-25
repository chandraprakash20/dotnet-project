import { faqData } from "./faqData";

export interface faqListResponse {
    result: string;
    message: string;
    data: faqData[];
}