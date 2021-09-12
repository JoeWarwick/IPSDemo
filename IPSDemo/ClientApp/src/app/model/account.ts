export class Person {
  id:	string;
  title:	string;
  firstName:	string;
  lastName:	string;
  dob:	Date;
}

export class PersonalAccount {
  id:	string;
  title:	string;
  firstName:	string;
  lastName:	string;
  dob:	Date;
  accountName:	string;
  tfn:	string;
  bankAccountNo:	string;
  bankAccountBSB:	string;
  noOfPersonnel:	number;
  personnel: Person[];
}

  export class CompanyOfficer extends Person {}

  export class CorporateAccount {
    id:	string;
    title:	string;
    firstName:	string;
    lastName:	string;
    dob:	Date;
    accountName:	string;
    companyName:	string;
    abn:	string;
    bankAccountNo:	string;
    bankAccountBSB:	string;
    noOfCompanyOfficers: number;
    companyOfficers: CompanyOfficer[];
  }
