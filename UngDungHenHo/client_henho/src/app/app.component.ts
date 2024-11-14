import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);

  title = 'DatingApp';
  users: any;

  ngOnInit(): void {
    this.http.get('http://localhost:8686/api/Users').subscribe({
      next: response => this.users = response,
      error: error => console.error(error),
      complete: () => console.log('Request has completed')
    })
  }
}
