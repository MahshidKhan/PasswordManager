import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatOptionModule } from '@angular/material/core';
import { PasswordDialogComponent } from '../password-dialog/password-dialog.component';
import { Observable, map } from 'rxjs';
import { MatFabButton } from '@angular/material/button';
import { PasswordEntry, PasswordService } from '../../services/password.service';

@Component({
  selector: 'app-password-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    MatTooltipModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule
  ],
  templateUrl: './password-list.component.html',
  styleUrl: './password-list.component.scss'
})
export class PasswordListComponent implements OnInit {
  passwords$!: Observable<PasswordEntry[]>;
  filteredPasswords$!: Observable<PasswordEntry[]>;
  searchTerm = '';
  selectedCategory = '';

  categories = [
    { value: '', label: 'All Categories' },
    { value: 'work', label: 'Work' },
    { value: 'personal', label: 'Personal' },
    { value: 'school', label: 'School' },
    { value: 'social', label: 'Social Media' },
    { value: 'shopping', label: 'Shopping' },
    { value: 'banking', label: 'Banking' },
    { value: 'entertainment', label: 'Entertainment' },
    { value: 'other', label: 'Other' }
  ];

  constructor(
    private passwordService: PasswordService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    // FIX: Set both passwords$ and filteredPasswords$
    this.passwords$ = this.passwordService.getPasswords();
    this.filteredPasswords$ = this.passwords$;
  }

  updateFilteredPasswords(): void {
    this.filteredPasswords$ = this.passwords$.pipe(
      map(passwords => passwords.filter(p => {
        const matchesSearch = !this.searchTerm || 
          p.app.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
          p.userName.toLowerCase().includes(this.searchTerm.toLowerCase());
        const matchesCategory = !this.selectedCategory || p.category === this.selectedCategory;
        return matchesSearch && matchesCategory;
      }))
    );
  }

  clearFilters(): void {
    this.searchTerm = '';
    this.selectedCategory = '';
    this.updateFilteredPasswords();
  }

  loadPasswords(): void {
    // FIX: Use getPasswords() instead of getAllPasswords()
    this.passwords$ = this.passwordService.getPasswords();
    this.updateFilteredPasswords();
  }

  onAddPassword(): void {
    const dialogRef = this.dialog.open(PasswordDialogComponent, {
      width: '500px',
      data: { mode: 'add' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadPasswords();
        this.snackBar.open('Password added successfully!', 'Close', { duration: 3000 });
      }
    });
  }

  onEdit(password: PasswordEntry): void {
    const dialogRef = this.dialog.open(PasswordDialogComponent, {
      width: '500px',
      data: { mode: 'edit', password }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadPasswords();
        this.snackBar.open('Password updated successfully!', 'Close', { duration: 3000 });
      }
    });
  }

  onDelete(password: PasswordEntry): void {
    if (confirm('Are you sure you want to delete this password?')) {
      this.passwordService.deletePassword(password.id);
    }
  }

  onView(password: PasswordEntry): void {
    const decryptedPassword = this.passwordService.getDecryptedPassword(password.id);
    alert(`Password: ${decryptedPassword}`);
  }

  getAppIcon(appName: string): string {
    const iconMap: { [key: string]: string } = {
      'outlook': 'email',
      'messenger': 'chat',
      'gmail': 'mail',
      'facebook': 'facebook',
      'instagram': 'camera_alt',
      'twitter': 'alternate_email',
      'linkedin': 'work',
      'github': 'code',
      'default': 'apps'
    };
    
    return iconMap[appName.toLowerCase()] || iconMap['default'];
  }
}