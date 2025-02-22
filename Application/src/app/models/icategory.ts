export interface Icategory {
    id: number,
    name: string,
}
export interface CategoryApiResponse{
    statusCode: number;
    meta: any;
    succeeded: boolean;
    message: string;
    errors: any;
    data: Icategory[];
}
