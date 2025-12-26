import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatChipsModule } from '@angular/material/chips';

export interface FilterOption {
  id: string;
  label: string;
}

@Component({
  selector: 'lib-filter-pills',
  standalone: true,
  imports: [CommonModule, MatChipsModule],
  templateUrl: './filter-pills.html',
  styleUrl: './filter-pills.scss',
})
export class FilterPills {
  @Input() options: FilterOption[] = [];
  @Input() selectedId = '';
  @Input() multiple = false;
  @Input() selectedIds: string[] = [];

  @Output() selectionChange = new EventEmitter<string>();
  @Output() multipleSelectionChange = new EventEmitter<string[]>();

  onSelect(option: FilterOption): void {
    if (this.multiple) {
      const index = this.selectedIds.indexOf(option.id);
      if (index === -1) {
        this.selectedIds = [...this.selectedIds, option.id];
      } else {
        this.selectedIds = this.selectedIds.filter((id) => id !== option.id);
      }
      this.multipleSelectionChange.emit(this.selectedIds);
    } else {
      this.selectedId = option.id;
      this.selectionChange.emit(option.id);
    }
  }

  isSelected(option: FilterOption): boolean {
    if (this.multiple) {
      return this.selectedIds.includes(option.id);
    }
    return this.selectedId === option.id;
  }
}
