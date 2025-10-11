export type Product = {
    id: string,
    name: string,
    description? : string,
    sku?: string,
    price: number,
    isActive: boolean
}