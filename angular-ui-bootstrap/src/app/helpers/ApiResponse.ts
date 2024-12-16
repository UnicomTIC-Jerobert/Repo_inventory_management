export interface ApiResponse<T> {
    success: boolean;
    payload: T;
    title: string;
    errors: any[];
}
