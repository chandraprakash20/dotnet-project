import { foodCourtData } from "./foodCourtData";

export interface FoodCourtListResponse {
    result: string;
    message: string;
    data: foodCourtData[];
}