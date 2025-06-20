import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PasswordListComponent } from './components/password-list/password-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, PasswordListComponent],  
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'password-manager-final';
}