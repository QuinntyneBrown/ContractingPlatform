import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header, Footer } from './components';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Header, Footer],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {}
