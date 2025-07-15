export interface Client {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  preferredContact: string;
  address: string;
  city: string;
  postalCode: string;
  country: string;
  dateOfBirth: Date;
  budgetMin: number;
  budgetMax: number;
  isActive: boolean;
  notes: string;
  createdAt: Date;
  updatedAt: Date;
  priorityNo?: number;
  priorityAmount?: number;
  
}