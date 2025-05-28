export interface NewsDto {
    id: number | undefined;
    title: string;
    description: string;
    imageLink: string;
    author: string;
    createdAt: string | undefined;
}