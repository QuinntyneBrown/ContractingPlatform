import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatExpansionModule } from '@angular/material/expansion';

export interface FaqItem {
  question: string;
  answer: string;
}

@Component({
  selector: 'lib-faq-accordion',
  standalone: true,
  imports: [CommonModule, MatExpansionModule],
  templateUrl: './faq-accordion.html',
  styleUrl: './faq-accordion.scss',
})
export class FaqAccordion {
  @Input() items: FaqItem[] = [];
  @Input() multi = false;
}
