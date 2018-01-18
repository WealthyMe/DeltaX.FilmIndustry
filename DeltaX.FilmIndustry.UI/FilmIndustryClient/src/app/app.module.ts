import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Ng2CompleterModule } from 'ng2-completer';
import { NgbModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ScrollToModule } from 'ng2-scroll-to';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AddEditMovieComponent } from './Movie/Components/add-edit-movie/add-edit-movie.component';
import { AddEditPersonComponent } from './Person/Components/add-edit-person/add-edit-person.component';
import { PersonService } from './Person/Services/person.service';
import { DropdownComponent } from './Shared/Components/dropdown/dropdown.component';
import { AlertInlineComponent } from './Shared/Components/alert-inline/alert-inline.component';
import { PersonListComponent } from './Person/Components/person-list/person-list.component';
import { PersonSmartSearchComponent } from './Person/Components/person-smart-search/person-smart-search.component';
import { MovieService } from './Movie/Services/movie.service';
import { MovieListComponent } from './Movie/Components/movie-list/movie-list.component';


@NgModule({
  declarations: [
    AppComponent,
    AddEditMovieComponent,
    AddEditPersonComponent,
    DropdownComponent,
    AlertInlineComponent,
    PersonListComponent,
    PersonSmartSearchComponent,
    MovieListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    FormsModule,
    Ng2CompleterModule,
    NgbModule.forRoot(),
    ScrollToModule.forRoot()
  ],
  providers: [PersonService, MovieService],
  bootstrap: [AppComponent],
  entryComponents: [AddEditPersonComponent]
})
export class AppModule { }
