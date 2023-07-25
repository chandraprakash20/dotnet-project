import { eventData } from "./eventData";

export interface EventListResponse {
    result: string;
    message: string;
    data: eventData[];
}