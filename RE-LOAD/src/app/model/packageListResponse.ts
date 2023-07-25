import { packageData } from "./packageData";

export interface packageListResponse {
    result: string;
    message: string;
    data: packageData[];
}