import { Component, Input } from '@angular/core';
import { NavigationEmployeeItems } from '../../navigation-employee';
import { Location,LocationStrategy } from '@angular/common';

@Component({
  selector: 'app-nav-group-employee',
  templateUrl: './nav-group-employee.component.html',
  styleUrls: ['./nav-group-employee.component.scss']
})
export class NavGroupEmployeeComponent {
  @Input() item!: NavigationEmployeeItems;

  // Constructor
  constructor(
    private location: Location,
    private locationStrategy: LocationStrategy
  ) {}

  // Life cycle events
  ngOnInit() {
    // at reload time active and trigger link
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
}
