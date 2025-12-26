import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'cp-project-card',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatChipsModule],
  templateUrl: './project-card.html',
  styleUrl: './project-card.scss',
})
export class ProjectCard {
  @Input() imageUrl = '';
  @Input() imageAlt = '';
  @Input() title = '';
  @Input() category = '';
  @Input() location = '';
  @Output() cardClick = new EventEmitter<void>();

  onCardClick(): void {
    this.cardClick.emit();
  }
}
