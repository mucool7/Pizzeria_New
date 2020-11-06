import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomizeComponent } from './Modules/Main/Pages/customize/customize.component';
import { HomeComponent } from './Modules/Main/Pages/home/home.component';
import { OrderHistoryComponent } from './Modules/Main/Pages/order-history/order-history.component';
import { OrderPlacedComponent } from './Modules/Main/Pages/order-placed/order-placed.component';

const routes: Routes = [
  {path:"" ,component:HomeComponent},
  {path:"home" ,component:HomeComponent},
  {path:"custom" ,component:CustomizeComponent},
  {path:"orderplaced" ,component:OrderPlacedComponent},
  {path:"history" ,component:OrderHistoryComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
