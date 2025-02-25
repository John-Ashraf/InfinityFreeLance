export interface Iorder{
    ProductName: string;
    Quantity: number;
    PhoneNumber: string;
    Size: string;
    Address: string;
    Message: string;
    Photos: File[];
    date: string; // Add this field
    price: number; // Add this field
    totalPrice: number; // Add this field
}