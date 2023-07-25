import { userData } from "./userData";

export interface userDetailResponse {
    result: string;
    message: string;
    data: userData;
}