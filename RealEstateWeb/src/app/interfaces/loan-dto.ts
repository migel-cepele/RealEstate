export interface LoanDto {
  amount: number;
  interestRate: number;
  termMonths: number;
  startDate: Date;
  endDate: Date;
  monthlyPayment: number;
  currency: string;
  installments: LoanInstallment[];
}

export interface LoanInstallment {
  installmentNumber: number;
  principal: number;
  interest: number;
  totalPayment: number;
  dueDate: Date;
}