import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'cp-section-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './section-header.html',
  styleUrl: './section-header.scss',
})
export class SectionHeader {
  @Input() title = '';
  @Input() subtitle = '';
  @Input() alignment: 'left' | 'center' | 'right' = 'center';
}
