import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './weather/weather.component';
import { TodoComponent } from './todo/todo.component';
import { ReqListComponent } from './Components/Requisition/req-list/req-list.component';

const routes: Routes = [
   //{ path: '', component: HomeComponent, pathMatch: 'full' },
   //{ path: 'counter', component: CounterComponent },
   //{ path: 'weather', component: FetchDataComponent },
   //{ path: 'todo', component: TodoComponent },
  {path:'', component: ReqListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
