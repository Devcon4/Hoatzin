import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SiteState {
  constructor(public http: HttpClient) {}

  public sites = new BehaviorSubject<Site[] | undefined>(undefined);

  public getSites() {
    this.sites.next(undefined);
    this.http
      .get<Site[]>('@api/sites')
      .pipe(tap((sites) => this.sites.next(sites)))
      .subscribe();
  }
}

export type Site = {
  id: string;
  name: string;
};
