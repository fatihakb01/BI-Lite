export type Transaction = {
    id: string,
    totalAmount: number,
    transactionDate: Date,
    paymentMethod?: string,
    notes?: string,
    customerId: string
}
