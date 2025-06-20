import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { PasswordEntry, PasswordEntryCreate, PasswordEntryUpdate, PasswordService } from '../../services/password.service';


export interface DialogData {
  mode: 'add' | 'edit';
  password?: PasswordEntry;
}

@Component({
  selector: 'app-password-dialog',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './password-dialog.component.html',
  styleUrl: './password-dialog.component.scss'
})
export class PasswordDialogComponent implements OnInit {
  passwordForm: FormGroup;
  isEditMode: boolean;
  hidePassword = true;

  categories = [
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
    private fb: FormBuilder,
    private passwordService: PasswordService,
    public dialogRef: MatDialogRef<PasswordDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {
    this.isEditMode = data.mode === 'edit';
    this.passwordForm = this.createForm();
  }

  ngOnInit(): void {
    if (this.isEditMode && this.data.password) {
      this.loadPasswordData();
    }
  }

  createForm(): FormGroup {
    return this.fb.group({
      category: ['', Validators.required],
      app: ['', Validators.required],
      userName: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }
  loadPasswordData(): void {
    if (this.data.password) {
      // Get the decrypted password properly
      const decryptedPassword = this.passwordService.getDecryptedPassword(this.data.password.id);
      
      this.passwordForm.patchValue({
        category: this.data.password.category,
        app: this.data.password.app,
        userName: this.data.password.userName,
        password: decryptedPassword 
      });
    }
  }

  onSubmit(): void {
    if (this.passwordForm.valid) {
      const formData = this.passwordForm.value;
  
      if (this.isEditMode && this.data.password) {
        const updateData: PasswordEntryUpdate = {
          id: this.data.password.id,
          category: formData.category || '',
          app: formData.app || '',
          userName: formData.userName || '',
          password: formData.password || ''
        };
        this.passwordService.updatePassword(updateData);
      } else {
        const createData: PasswordEntryCreate = {
          category: formData.category || '',
          app: formData.app || '',
          userName: formData.userName || '',
          password: formData.password || ''
        };
        this.passwordService.addPassword(createData);
      }
  
      this.dialogRef.close(true);
    }
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }

  togglePasswordVisibility(): void {
    this.hidePassword = !this.hidePassword;
  }

  generatePassword(): void {
    const length = 12;
    const charset = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*';
    let password = '';
    
    for (let i = 0; i < length; i++) {
      password += charset.charAt(Math.floor(Math.random() * charset.length));
    }
    
    this.passwordForm.patchValue({ password });
  }
}