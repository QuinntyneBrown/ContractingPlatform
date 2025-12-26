import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'lib-testimonial-card',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule],
  templateUrl: './testimonial-card.html',
  styleUrl: './testimonial-card.scss',
})
export class TestimonialCard {
  @Input() quote = '';
  @Input() authorName = '';
  @Input() authorLocation = '';
  @Input() serviceType = '';
  @Input() rating = 5;

  get stars(): number[] {
    return Array(5)
      .fill(0)
      .map((_, i) => i);
  }
}
