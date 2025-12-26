import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'cp-trust-badge',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './trust-badge.html',
  styleUrl: './trust-badge.scss',
})
export class TrustBadge {
  @Input() icon = '';
  @Input() title = '';
  @Input() subtitle = '';
  @Input() variant: 'default' | 'compact' = 'default';
}
