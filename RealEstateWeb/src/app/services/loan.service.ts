import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoanDto } from '../interfaces/loan-dto';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
  private baseUrl = 'http://localhost:5028/api/loan';

  constructor(private http: HttpClient) {}

  // POST: api/loan/month/payment
  generateScheduleWithMonthlyPayment(
    interestRate: number,
    currency: string,
    loanAmount: number,
    monthlyPayment: number
  ): Observable<LoanDto> {
    const body = { interestRate, currency, loanAmount, monthlyPayment };
    return this.http.post<LoanDto>(`${this.baseUrl}/month/payment`, body);
  }

  // POST: api/loan/month/terms
  generateScheduleWithTermMonths(
    interestRate: number,
    currency: string,
    loanAmount: number,
    termMonths: number
  ): Observable<LoanDto> {
    const body = { interestRate, currency, loanAmount, termMonths };
    return this.http.post<LoanDto>(`${this.baseUrl}/month/terms`, body);
  }
}