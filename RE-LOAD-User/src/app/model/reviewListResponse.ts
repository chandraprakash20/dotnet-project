import { reviewData } from "./reviewData";

export interface reviewListResponse {
    result: string;
    message: string;
    data: reviewData[];
}