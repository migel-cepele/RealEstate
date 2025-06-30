export interface UserApplication {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNo: string;
  offerAmount: number;
  description: string;
  isAccepted: boolean;
  isRejected: boolean;
  houseId: number;
}