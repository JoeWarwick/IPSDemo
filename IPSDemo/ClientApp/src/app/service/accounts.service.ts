import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { CorporateAccount, PersonalAccount } from '../model/account';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  personalAccounts: PersonalAccount[];
  corporateAccounts: CorporateAccount[];
  baseUrl: string;
  http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
    this.refresh();
  }

  refresh(){
    this.http.get<PersonalAccount[]>(this.baseUrl + 'accounts/personal').subscribe(result => {
      this.personalAccounts = result;
    }, error => console.error(error));
    this.http.get<CorporateAccount[]>(this.baseUrl + 'accounts/corporate').subscribe(result => {
      this.corporateAccounts = result;
    }, error => console.error(error));
  }

  getPersonalAccounts() {
    return this.personalAccounts;
  }

  getCorporateAccounts() {
    return this.corporateAccounts;
  }
}
