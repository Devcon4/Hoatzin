import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, Component, OnInit } from '@angular/core';

import '@material/web/button/filled-button';
import '@material/web/icon/icon';
import '@material/web/iconbutton/icon-button';
import { DateTime } from 'luxon';
import { combineLatest, map } from 'rxjs';
import { ThemeState } from '../../../services/theme.service';
import { Check, CheckState } from '../../../states/check.state';
import { Site, SiteState } from '../../../states/site.state';
import CustomOperators from '../../../utils/custom-operators';
import { StatusGraphComponent } from '../../graph/status-graph/status-graph.component';

const mapChecks = (checks: Check[]) => {
  return checks.map((check) => {
    const dateCreated = DateTime.fromISO(check.dateCreated);
    const dateCompleted = check.dateCompleted
      ? DateTime.fromISO(check.dateCompleted)
      : undefined;

    // Difference between dateCreated and dateCompleted in milliseconds as a duration.
    const requestTime = dateCompleted
      ? dateCompleted.diff(dateCreated)
      : undefined;

    return {
      id: check.id,
      siteId: check.siteId,
      status: check.status.Value,
      dateCreated,
      dateCompleted,
      dateCreatedFormatted: dateCreated.toFormat('yyyy-MM-dd HH:mm:ss'),
      requestTime: requestTime?.toFormat('S') + ' ms',
    };
  });
};

export type CheckPresentation = ReturnType<typeof mapChecks>[number];

const siteStatusLookup = {
  Completed: 'OK',
  Failed: 'Down',
  Unknown: 'Unknown',
};

const mapSites = ([sites, checks]: [Site[], CheckPresentation[]]) => {
  return sites.map((site) => {
    const siteChecks = checks.filter((check) => check.siteId === site.id);
    const lastCheck = siteChecks[0];
    const status = (siteStatusLookup as any)[lastCheck?.status || 'Unknown'];
    return {
      id: site.id,
      name: site.name,
      status,
      up: lastCheck?.status === 'Completed',
      down: lastCheck?.status === 'Failed' || lastCheck?.status === 'Started',
      checks: siteChecks.sort(
        (a, b) => b.dateCreated.toMillis() - a.dateCreated.toMillis()
      ),
    };
  });
};

@Component({
  selector: 'zin-dashboard-page',
  standalone: true,
  imports: [CommonModule, StatusGraphComponent],
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.css'],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export default class DashboardPageComponent implements OnInit {
  constructor(
    private themeState: ThemeState,
    private SiteState: SiteState,
    private CheckState: CheckState
  ) {}

  isLight = this.themeState.isLight;
  isDark = this.themeState.isDark;

  checks = this.CheckState.checks.pipe(
    CustomOperators.IsDefinedSingle(),
    map(mapChecks)
  );

  sites = combineLatest([this.SiteState.sites, this.checks]).pipe(
    CustomOperators.IsDefinedTuple(),
    map(mapSites)
  );

  ngOnInit() {
    this.CheckState.GetChecks();
  }

  toggleTheme() {
    this.themeState.toggleTheme();
  }

  trackBySiteId(index: number, site: Site) {
    return site.id;
  }
}
