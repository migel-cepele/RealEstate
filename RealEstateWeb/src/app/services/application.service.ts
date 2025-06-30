import { Injectable } from '@angular/core';
import { UserApplication } from '../interfaces/userApplication';

@Injectable({ providedIn: 'root' })
export class ApplicationService {
    private readonly apiUrl = 'http://localhost:5028/api/application';

    async add(application: UserApplication): Promise<void> {
        await fetch(this.apiUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(application)
        });
    }

    async getAll(): Promise<UserApplication[]> {
        const response = await fetch(this.apiUrl);
        return response.json() as Promise<UserApplication[]>;
    }
}
