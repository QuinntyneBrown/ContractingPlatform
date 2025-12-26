import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'cp-team-card',
  standalone: true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './team-card.html',
  styleUrl: './team-card.scss',
})
export class TeamCard {
  @Input() imageUrl = '';
  @Input() name = '';
  @Input() role = '';
  @Input() description = '';
}
