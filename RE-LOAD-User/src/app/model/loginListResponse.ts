import { loginData } from "./loginData";

export interface loginListResponse {
    result: string;
    message: string;
    data: loginData[];
}