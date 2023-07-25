import { packageData } from "./packageData";

export interface packageDetailResponse {
    result: string;
    message: string;
    data: packageData;
}