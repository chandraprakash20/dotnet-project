import { userData } from "./userData";

export interface userListResponse {
    result: string;
    message: string;
    data: userData[];
}