import { Routes, RouterModule } from '@angular/router';
import { FrontPage } from './pages/front-page/front-page';
 // import { HeroesComponent } from './heroes.component';

const appRoutes: Routes = [
  {
    path: 'noobs',
    component: FrontPage
  },
  {
  path: '',
  redirectTo: '/noobs',
  pathMatch: 'full'
}

];


export const routing = RouterModule.forRoot(appRoutes);   