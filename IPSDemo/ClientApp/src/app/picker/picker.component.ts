import { AfterViewInit, Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
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
export class PickerComponent implements AfterViewInit {
  accountControl = new FormControl('', Validators.required);
  countControl = new FormControl('', Validators.required);
  personalSelected: boolean = true;
  corporateSelected: boolean = false;
  numberOfIndividuals: number = 0;
  personalAccount: PersonalAccount;
  corporateAccount: CorporateAccount;

  constructor(private accountService: AccountsService) {
  }

  async ngAfterViewInit(): Promise<void> {
    let pa = await this.accountService.getPersonalAccounts();
    if(pa?.length){
      this.personalAccount = pa[0];
    }
    let ca = await this.accountService.getCorporateAccounts();
    if(ca?.length){
      this.corporateAccount = ca[0];
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
