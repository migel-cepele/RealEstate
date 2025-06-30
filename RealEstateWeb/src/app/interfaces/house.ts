export interface House {
  id: number;
  name: string;
  city: string;
  state: string;
  photo: string;
  availableUnits: number;
  wifi: boolean;
  laundry: boolean;
  photoLocal?: string | ArrayBuffer | null; // base64 or null for local photo
}