import { offersData } from "./offersData";

export interface offersListResponse {
    result: string;
    message: string;
    data: offersData[];
}