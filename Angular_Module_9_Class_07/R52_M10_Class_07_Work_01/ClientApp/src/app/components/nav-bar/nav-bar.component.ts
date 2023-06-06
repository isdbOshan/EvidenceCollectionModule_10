import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { navItems } from 'src/app/models/app-const';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

    navs = navItems;
    config = {
      paddingAtStart: true,
      interfaceWithRoute: true,
      classname: 'my-custom-class',
      listBackgroundColor: `rgb(208, 241, 239)`,
      fontColor: `rgb(8, 54, 71)`,
      backgroundColor: `rgb(208, 241, 239)`,
      selectedListFontColor: `red`,
      highlightOnSelect: true,
      collapseOnSelect: true,
      useDividers: false,
      rtlLayout: false
  };
  

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
  .pipe(
    map(result => result.matches),
    shareReplay()
  );

constructor(private breakpointObserver: BreakpointObserver) {}

}

