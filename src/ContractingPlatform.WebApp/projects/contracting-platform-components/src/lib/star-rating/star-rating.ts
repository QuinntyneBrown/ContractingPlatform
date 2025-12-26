import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'lib-star-rating',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './star-rating.html',
  styleUrl: './star-rating.scss',
})
export class StarRating {
  @Input() rating = 5;
  @Input() maxRating = 5;
  @Input() size: 'small' | 'medium' | 'large' = 'medium';
  @Input() showValue = false;

  get stars(): number[] {
    return Array(this.maxRating)
      .fill(0)
      .map((_, i) => i);
  }
}
