import type {NewsDto} from "./newsDto.ts";

export interface GetNewsResponse {
    newsDtos: NewsDto[];
}