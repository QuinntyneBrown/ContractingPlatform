import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'cp-statistic',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './statistic.html',
  styleUrl: './statistic.scss',
})
export class Statistic {
  @Input() value = '';
  @Input() label = '';
  @Input() suffix = '';
  @Input() variant: 'default' | 'inverted' = 'default';
}
