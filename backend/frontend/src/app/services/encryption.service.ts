import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EncryptionService {

  constructor() { }

  /**
   * Encrypt password using Base64 encoding
   */
  encryptPassword(password: string): string {
    try {
      return btoa(password); // Base64 encode
    } catch (error) {
      console.error('Error encrypting password:', error);
      throw new Error('Failed to encrypt password');
    }
  }

  /**
   * Decrypt password using Base64 decoding
   */
  decryptPassword(encryptedPassword: string): string {
    try {
      return atob(encryptedPassword); // Base64 decode
    } catch (error) {
      console.error('Error decrypting password:', error);
      throw new Error('Failed to decrypt password');
    }
  }

  /**
   * Validate if string is valid Base64
   */
  isValidBase64(str: string): boolean {
    try {
      return btoa(atob(str)) === str;
    } catch (err) {
      return false;
    }
  }
}