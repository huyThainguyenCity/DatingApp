import { Component, EventEmitter, inject, input, Input, output, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  //2 cach truyen du lieu sang tu trang cha sang trang con
  // @Input() usersFromHomeComponent: any;
  // usersFromHomeComponent = input.required<any>();

  //2 cach truyen du lieu sang tu trang con sang trang cha
  // @Output() cancelRegister = new EventEmitter();
  cancelRegister = output<boolean>();
  model: any = {}

  register() {
    console.log(this.model);
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
      },
      error: error => console.log(error)
    });

  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}


