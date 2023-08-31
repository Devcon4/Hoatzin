import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { webSocket } from 'rxjs/webSocket';
import { ConfigService } from '../services/config.service';

@Injectable({
  providedIn: 'root',
})
export class CheckState {
  checkConnection = this.CreateCheckConnection();

  checks = new BehaviorSubject<Check[]>([]);

  constructor(private configService: ConfigService) {}

  GetChecks() {
    this.checkConnection.subscribe((checks) => {
      this.checks.next(checks);
    });
    this.checkConnection.next([]);
  }

  CreateCheckConnection() {
    var config = this.configService.AppConfig.getValue()?.clients.ws;
    var url = `${config?.host}/${config?.prefix}/checks`;
    return webSocket<Check[]>(url);
  }
}

export type Check = {
  id: string;
  siteId: string;
  dateCreated: string;
  dateCompleted?: string;
  status: {
    Value: string;
  };
};
