export interface Iorder{
    ProductId: number;
    Quantity: number;
    Phone: string;
    size: string;
    Address: string;
    Notes: string;
    PicsCustom: File[];
    date: string; // Add this field
    price: number; // Add this field
    totalPrice: number; // Add this field
}