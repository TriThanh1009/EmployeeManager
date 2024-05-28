import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { NavigationEmployeeItem } from '../navigation-employee';
import { Location,LocationStrategy } from '@angular/common';

@Component({
  selector: 'app-nav-content-employee',
  templateUrl: './nav-content-employee.component.html',
  styleUrls: ['./nav-content-employee.component.scss']
})
export class NavContentEmployeeComponent implements OnInit {
// public props
@Output() NavCollapsedMob: EventEmitter<string> = new EventEmitter();

// version
title = '';
currentApplicationVersion = environment.appVersion;

navigation;
windowWidth = window.innerWidth;

// Constructor
constructor(
  public nav: NavigationEmployeeItem,
  private location: Location,
  private locationStrategy: LocationStrategy
) {
  this.windowWidth;
  this.navigation = this.nav.get();
}

// Life cycle events
ngOnInit() {
  if (this.windowWidth < 1025) {
    (document.querySelector('.coded-navbar') as HTMLDivElement).classList.add('menupos-static');
  }
}

fireOutClick() {

  let current_url = this.location.path();
  const baseHref = this.locationStrategy.getBaseHref();
  if (baseHref) {
    current_url = baseHref + this.location.path();
  }

  const link = "a.nav-link[ href='" + current_url + "' ]";
  const ele = document.querySelector(link);
  if (ele !== null && ele !== undefined) {
    const parent = ele.parentElement;
    const up_parent = parent?.parentElement?.parentElement;
    const last_parent = up_parent?.parentElement;
    if (parent?.classList.contains('coded-hasmenu')) {
      parent.classList.add('coded-trigger');
      parent.classList.add('active');
    } else if (up_parent?.classList.contains('coded-hasmenu')) {
      up_parent.classList.add('coded-trigger');
      up_parent.classList.add('active');
    } else if (last_parent?.classList.contains('coded-hasmenu')) {
      last_parent.classList.add('coded-trigger');
      last_parent.classList.add('active');
    }
  }
}

navMob() {

  if (this.windowWidth < 1025 && document.querySelector('app-navigation.coded-navbar').classList.contains('mob-open')) {
    this.NavCollapsedMob.emit();

  }
}
}
