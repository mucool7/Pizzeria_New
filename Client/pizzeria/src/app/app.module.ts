import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Modules/Main/Pages/home/home.component';
import { HttpService } from './Shared/Providers/http.service';
import { HomeService } from './Modules/Main/Providers/home.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ProductDisplayComponent } from './Modules/Main/Components/product-display/product-display.component';
import { CustomizeComponent } from './Modules/Main/Pages/customize/customize.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderPlacedComponent } from './Modules/Main/Pages/order-placed/order-placed.component';
import { OrderHistoryComponent } from './Modules/Main/Pages/order-history/order-history.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductDisplayComponent,
    CustomizeComponent,
    OrderPlacedComponent,
    OrderHistoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [HttpService,HomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
