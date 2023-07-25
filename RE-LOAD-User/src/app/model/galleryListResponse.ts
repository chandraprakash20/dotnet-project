import { galleryData } from "./galleryData";

export interface galleryListResponse {
    result: string;
    message: string;
    data: galleryData[];
}