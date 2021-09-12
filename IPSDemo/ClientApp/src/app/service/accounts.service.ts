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
  }

  async getPersonalAccounts() {
    let res = await this.http.get<PersonalAccount[]>(this.baseUrl + 'api/accounts/personal').toPromise();
    this.personalAccounts = res;
    return this.personalAccounts;
  }

  async getCorporateAccounts() {
    let res = await this.http.get<CorporateAccount[]>(this.baseUrl + 'api/accounts/corporate').toPromise();
    this.corporateAccounts = res;
    return this.corporateAccounts;
  }

  savePersonal(personalAccount: PersonalAccount){
    this.http.post(this.baseUrl + 'api/accounts/personal', personalAccount);
  }

  saveCorporate(corporateAccount: CorporateAccount){
    this.http.post(this.baseUrl + 'api/accounts/corporate', corporateAccount);
  }
}
