import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

export interface ProcessStep {
  number: number;
  title: string;
  description: string;
}

@Component({
  selector: 'lib-process-timeline',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './process-timeline.html',
  styleUrl: './process-timeline.scss',
})
export class ProcessTimeline {
  @Input() steps: ProcessStep[] = [];
  @Input() variant: 'horizontal' | 'vertical' = 'horizontal';
}
