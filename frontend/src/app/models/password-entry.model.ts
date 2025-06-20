export interface PasswordEntry {
    id: number;
    category: string;
    app: string;
    userName: string;
    encryptedPassword: string;
    createdAt?: Date;
    updatedAt?: Date;
  }
  
  export interface PasswordEntryCreate {
    category: string;
    app: string;
    userName: string;
    password: string; 
  }
  
  export interface PasswordEntryUpdate {
    id: number;
    category?: string;
    app?: string;
    userName?: string;
    password?: string; 
  }export interface PasswordEntry {
    id: number;
    category: string;
    app: string;
    userName: string;
    encryptedPassword: string;
    createdAt?: Date;
    updatedAt?: Date;
  }
  
  export interface PasswordEntryCreate {
    category: string;
    app: string;
    userName: string;
    password: string; 
  }
  
  export interface PasswordEntryUpdate {
    id: number;
    category?: string;
    app?: string;
    userName?: string;
    password?: string; 
  }