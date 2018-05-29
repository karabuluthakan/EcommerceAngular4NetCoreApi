import {Component,OnInit} from '@angular/core';
import { UserService } from '../services/User.service';
import { User } from '../Models/User';
import{FormGroup,FormBuilder,Validators} from '@angular/forms';
import {NgClass} from '@angular/common';
import { Router } from '@angular/router';

@Component({
selector:'selector-name',
templateUrl:'detail.component.html'
})

export class DetailComponent implements OnInit{ 
    userModel:User;
    constructor(private userService:UserService,private router:Router) { 
        this.userModel=  this.userService.SelectedUser;
    }

    ngOnInit(){}

    UpdateUser(){
        this.userService.UpdateUser(this.userModel).subscribe(result=>console.log());
        this.router.navigate(['/components/tables']);
    }
}