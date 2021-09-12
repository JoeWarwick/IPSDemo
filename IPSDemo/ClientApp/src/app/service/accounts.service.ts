import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { CorporateAccount, PersonalAccount } from '../model/account';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  public personalAccounts: PersonalAccount[];
  public corporateAccounts: CorporateAccount[];
  baseUrl: string;
  http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
    this.refresh();
  }

  refresh(){
    this.http.get<PersonalAccount[]>(this.baseUrl + 'api/accounts/personal').subscribe(result => {
      this.personalAccounts = result;
    }, error => console.error(error));
    this.http.get<CorporateAccount[]>(this.baseUrl + 'api/accounts/corporate').subscribe(result => {
      this.corporateAccounts = result;
    }, error => console.error(error));
  }

  getPersonalAccounts() {
    return this.personalAccounts;
  }

  getCorporateAccounts() {
    return this.corporateAccounts;
  }

  savePersonal(personalAccount: PersonalAccount){
    this.http.post(this.baseUrl + 'api/accounts/personal', personalAccount);
    this.refresh();
  }

  saveCorporate(corporateAccount: CorporateAccount){
    this.http.post(this.baseUrl + 'api/accounts/corporate', corporateAccount);
    this.refresh();
  }
}
