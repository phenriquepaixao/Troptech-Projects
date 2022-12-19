import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ViewStatusComponent } from './components/view-status/view-status.component';
import { ChangeStatusComponent } from './components/change-status/change-status.component';

@NgModule({
  declarations: [
    AppComponent,
    ViewStatusComponent,
    ChangeStatusComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
