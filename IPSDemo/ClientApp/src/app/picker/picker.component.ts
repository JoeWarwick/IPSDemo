import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { CorporateAccount, Person, PersonalAccount } from '../model/account';
import { AccountsService } from '../service/accounts.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';

@Component({
  selector: 'app-picker',
  templateUrl: './picker.component.html',
  styleUrls: ['./picker.component.css']
})
export class PickerComponent implements OnChanges {
  accountControl = new FormControl('', Validators.required);
  countControl = new FormControl('', Validators.required);
  personalSelected: boolean = false;
  corporateSelected: boolean = false;
  numberOfIndividuals: number = 0;
  personalAccount: PersonalAccount;
  corporateAccount: CorporateAccount;

  constructor(private accountService: AccountsService) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if(this.accountService.personalAccounts.length > 0){
      this.personalAccount = this.accountService.personalAccounts[0];
    }
    if(this.accountService.corporateAccounts.length > 0){
      this.corporateAccount = this.accountService.corporateAccounts[0];
    }
  }

  onAccountChange = (val: string) => {
    if(val === 'Personal'){
      this.personalAccount = new PersonalAccount();
      this.personalSelected = true;
    }
    if(val === 'Corporate'){
      this.corporateAccount = new CorporateAccount();
      this.corporateSelected = true;
    }
  }

  onCountChange = (val: number) => {
    if(!this.personalAccount && !this.corporateAccount)
      this.onAccountChange('Personal');
    if(this.personalSelected){
      let currCount = this.personalAccount.noOfPersonnel;
      if(currCount > val){
        for(let i = currCount; i <= val; i++){
          this.personalAccount.personnel.pop();
        }
      }
      else if(currCount < val){
        for(let i = currCount; i <= val; i++){
          this.personalAccount.personnel.push(new Person());
        }
      }
      this.personalAccount.noOfPersonnel = val;
    }
  }

  onCorporateSave = () => {
    this.accountService.saveCorporate(this.corporateAccount);
  }

  onPersonalSave = () => {
    this.accountService.savePersonal(this.personalAccount);
  }

}
