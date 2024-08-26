import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbCollapseModule, NgbDropdownModule, NgbModule, NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { NgScrollbarModule } from 'ngx-scrollbar'; // Import NgScrollbarModule from the correct package
import { CardComponent } from './components/card/card.component';
import {  provideHttpClient } from '@angular/common/http';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { SearchInputComponent } from './components/input-components/search-input/search-input.component';
import { AvtComponent } from './components/avt/avt.component';
import { LanguageInputComponent } from './components/input-components/language-input/language-input.component';
import { TextInputComponent } from './components/input-components/text-input/text-input.component';
import { SpinnerAlphaComponent } from './components/spinner-alpha/spinner-alpha.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbDropdownModule,
    NgbNavModule,
    NgbModule,
    NgbCollapseModule,
    CardComponent,
  ],providers: [provideHttpClient()],
  declarations: [SpinnerAlphaComponent,SpinnerComponent, SearchInputComponent, AvtComponent,LanguageInputComponent,TextInputComponent],
  
  exports: [SpinnerAlphaComponent,LanguageInputComponent,TextInputComponent]
})
export class ShareModule { }
