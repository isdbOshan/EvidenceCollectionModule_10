import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
//   navs = navItems;
//   config = {
//     paddingAtStart: true,
//     interfaceWithRoute: true,

//     useDividers: true,
//     rtlLayout: false
// };

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
config: any;
navs: any;

  constructor(private breakpointObserver: BreakpointObserver) {}

}
