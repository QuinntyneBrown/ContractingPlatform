import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

export type ButtonVariant = 'primary' | 'secondary' | 'outlined' | 'text';
export type ButtonSize = 'small' | 'medium' | 'large';

@Component({
  selector: 'cp-button',
  standalone: true,
  imports: [CommonModule, MatButtonModule, MatIconModule],
  templateUrl: './button.html',
  styleUrl: './button.scss',
})
export class Button {
  @Input() variant: ButtonVariant = 'primary';
  @Input() size: ButtonSize = 'medium';
  @Input() disabled = false;
  @Input() fullWidth = false;
  @Input() icon?: string;
  @Input() iconPosition: 'left' | 'right' = 'left';

  get buttonClass(): string {
    return `button button--${this.variant} button--${this.size}`;
  }
}
