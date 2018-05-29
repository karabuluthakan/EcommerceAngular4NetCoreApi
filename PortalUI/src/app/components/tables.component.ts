import { Component } from '@angular/core';
import { UserService } from '../services/User.service';
import { User } from '../Models/User';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'tables.component.html'
})
export class TablesComponent {
  userList:any;
  constructor(private userservice:UserService,private router:Router) {
    this.getAllUser();
   }

  getAllUser(){
    this.userservice.GetAllUsers().subscribe(result=>this.userList=result);
  }
  editUser(user:User){
    this.userservice.SelectedUser=user;
    this.router.navigate(["components/detail"])
  }
}
