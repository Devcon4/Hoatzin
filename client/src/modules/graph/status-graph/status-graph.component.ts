import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { CheckPresentation } from '../../dashboard/dashboard-page/dashboard-page.component';

@Component({
  selector: 'zin-status-graph',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './status-graph.component.html',
  styleUrls: ['./status-graph.component.css'],
})
export class StatusGraphComponent {
  @Input() checks: CheckPresentation[] = [];

  trackByCheckId(index: number, check: CheckPresentation) {
    return check.id;
  }
}
