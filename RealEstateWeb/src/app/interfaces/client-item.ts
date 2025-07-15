export interface ClientItem {
  id: number;
  clientId: number;
  itemId: number;
  status: string;
  notes: string;
  createdAt: Date;
  updatedAt: Date;
  isActive: boolean;
  price: number;
  discount: number;
  commission: number;
  paymentMethod: string;
  currency: string;
}