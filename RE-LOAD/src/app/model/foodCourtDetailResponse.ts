import { foodCourtData } from "./foodCourtData";

export interface FoodCourtDetailResponse {
    result: string;
    message: string;
    data: foodCourtData;
}