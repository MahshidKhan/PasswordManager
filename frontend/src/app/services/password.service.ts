import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';

export interface PasswordEntry {
  id: number;
  category: string;
  app: string;
  userName: string;
  encryptedPassword: string;
  createdAt: string;
  updatedAt: string;
}

export interface PasswordEntryCreate {
  category: string;
  app: string;
  userName: string;
  password: string;
}

export interface PasswordEntryUpdate {
  id: number;
  category: string;
  app: string;
  userName: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class PasswordService {
  private readonly apiUrl = 'http://localhost:5234/api/password';
  private passwordsSubject = new BehaviorSubject<PasswordEntry[]>([]);
  public passwords$ = this.passwordsSubject.asObservable();

  constructor(private http: HttpClient) {
    this.loadPasswordsFromAPI();
  }

  private loadPasswordsFromAPI(): void {
    this.http.get<PasswordEntry[]>(this.apiUrl).subscribe({
      next: (passwords) => {
        console.log('Loaded from API:', passwords);
        this.passwordsSubject.next(passwords);
      },
      error: (error) => {
        console.error('Failed to load passwords:', error);
      }
    });
  }

  getPasswords(): Observable<PasswordEntry[]> {
    return this.passwords$;
  }

  addPassword(passwordData: PasswordEntryCreate): void {
    this.http.post<PasswordEntry>(this.apiUrl, passwordData).subscribe({
      next: (createdPassword) => {
        console.log('Password created:', createdPassword);
        this.loadPasswordsFromAPI(); // Refresh the list
      },
      error: (error) => {
        console.error('Failed to create password:', error);
      }
    });
  }

  updatePassword(passwordData: PasswordEntryUpdate): void {
    this.http.put<PasswordEntry>(`${this.apiUrl}/${passwordData.id}`, passwordData).subscribe({
      next: (updatedPassword) => {
        console.log('Password updated:', updatedPassword);
        this.loadPasswordsFromAPI(); // Refresh the list
      },
      error: (error) => {
        console.error('Failed to update password:', error);
      }
    });
  }

  deletePassword(id: number): void {
    this.http.delete(`${this.apiUrl}/${id}`).subscribe({
      next: () => {
        console.log('Password deleted:', id);
        this.loadPasswordsFromAPI(); // Refresh the list
      },
      error: (error) => {
        console.error('Failed to delete password:', error);
      }
    });
  }

  getDecryptedPassword(id: number): string {
    const passwords = this.passwordsSubject.value;
    const password = passwords.find((p: PasswordEntry) => p.id === id);
    
    if (password && password.encryptedPassword) {
      try {
        return atob(password.encryptedPassword);
      } catch (error: any) {
        console.error('Error decrypting password:', error);
        return '';
      }
    }
    
    return '';
  }
}