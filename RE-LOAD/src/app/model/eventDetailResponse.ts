import { eventData } from "./eventData";

export interface EventDetailResponse {
    result: string;
    message: string;
    data: eventData;
}