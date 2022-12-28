import { Component, OnInit } from '@angular/core';
import { RequisitionClient, RequisitionDto } from '../../../web-api-client';

@Component({
  selector: 'app-req-list',
  templateUrl: './req-list.component.html',
  styleUrls: ['./req-list.component.scss']
})
export class ReqListComponent implements OnInit {

  lists: any;

  //lists: RequisitionDto[];
  selectedList: RequisitionDto;
  constructor(
    private listsClient: RequisitionClient) { }

  ngOnInit(): void {
    //this.listsClient.get().subscribe(
    //  result => {
    //    this.lists = result.lists;
    //    console.log(this.lists);
    //    if (this.lists.length) {
    //      this.selectedList = this.lists[0];
    //    }
    //  },
    //  error => console.error(error)
    //);
    this.getAlllists()
  }

  getAlllists() {
    this.listsClient.getRequesition().subscribe((data) => {
      this.lists = data;
      console.log(data);
    })
  }
}
