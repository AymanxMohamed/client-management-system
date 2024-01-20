export class Client {
  id?: string;
  name: string;
  emailAddress: string;
  phoneNumber: string;
  homeAddress: string;
  checked?: boolean;
}

export class Email {
  subject: string;
  receiverEmail: string;
  body: string;
}
