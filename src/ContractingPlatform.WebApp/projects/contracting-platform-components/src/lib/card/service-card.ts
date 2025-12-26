import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'lib-service-card',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule, MatButtonModule],
  templateUrl: './service-card.html',
  styleUrl: './service-card.scss',
})
export class ServiceCard {
  @Input() icon = '';
  @Input() title = '';
  @Input() description = '';
  @Input() linkText = 'Learn More';
  @Output() linkClick = new EventEmitter<void>();

  onLinkClick(): void {
    this.linkClick.emit();
  }
}
