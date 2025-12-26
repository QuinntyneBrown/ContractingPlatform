import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'lib-hero-section',
  standalone: true,
  imports: [CommonModule, MatButtonModule],
  templateUrl: './hero-section.html',
  styleUrl: './hero-section.scss',
})
export class HeroSection {
  @Input() title = '';
  @Input() subtitle = '';
  @Input() breadcrumb = '';
  @Input() backgroundImage = '';
  @Input() overlayOpacity = 0.6;
  @Input() primaryButtonText = '';
  @Input() secondaryButtonText = '';
  @Input() variant: 'full' | 'compact' = 'full';

  @Output() primaryClick = new EventEmitter<void>();
  @Output() secondaryClick = new EventEmitter<void>();

  onPrimaryClick(): void {
    this.primaryClick.emit();
  }

  onSecondaryClick(): void {
    this.secondaryClick.emit();
  }
}
