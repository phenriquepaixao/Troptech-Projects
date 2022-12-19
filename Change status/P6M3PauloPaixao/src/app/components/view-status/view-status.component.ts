import { Component, Input, OnInit } from '@angular/core';
import { IStatus } from 'src/app/IStatus';

@Component({
  selector: 'app-view-status',
  templateUrl: './view-status.component.html',
  styleUrls: ['./view-status.component.css']
})
export class ViewStatusComponent implements OnInit {

  arrayStatus: IStatus[] = [
    { index: 1, value: 'Recebido', status: false, class: '', style: '100' },//class initial:'', stated:'started', finished: 'finished'
    { index: 2, value: 'Em preparação', status: false, class: '', style: '100' },
    { index: 3, value: 'Pronto', status: false, class: '', style: '100' },
    { index: 4, value: 'Entregue', status: false, class: '', style: '100' },
  ];

  valueStatus: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  onChangeStatus(value: string) {
    switch (value) {
      case "1":
        this.valueStatus = "Recebido"
        this.arrayStatus[0].class = "started";
        this.arrayStatus[0].style = "bold";

        this.arrayStatus[1].class = "";
        this.arrayStatus[2].class = "";
        this.arrayStatus[3].class = "";

        break;
      case "2":
        this.valueStatus = "Em preparação"
        this.arrayStatus[1].class = "started";
        this.arrayStatus[1].style = "bold";

        this.arrayStatus[0].class = "";
        this.arrayStatus[2].class = "";
        this.arrayStatus[3].class = "";
        
        this.arrayStatus[0].style = "100";
        this.arrayStatus[2].style = "100";
        this.arrayStatus[3].style = "100";

        break;
      case "3":
        this.valueStatus = "Pronto"
        this.arrayStatus[2].class = "started";
        this.arrayStatus[2].style = "bold";

        this.arrayStatus[0].class = "";
        this.arrayStatus[1].class = "";
        this.arrayStatus[3].class = "";

        this.arrayStatus[0].style = "100";
        this.arrayStatus[1].style = "100";
        this.arrayStatus[3].style = "100";

        break;
      case "4":
        this.valueStatus = "Entregue"
        this.arrayStatus[3].class = "started";
        this.arrayStatus[3].style = "bold";

        this.arrayStatus[0].class = "";
        this.arrayStatus[1].class = "";
        this.arrayStatus[2].class = "";

        this.arrayStatus[0].style = "100";
        this.arrayStatus[1].style = "100";
        this.arrayStatus[2].style = "100";

        break;
      default:
        this.valueStatus = ""
        this.arrayStatus[0].class = "";
        this.arrayStatus[1].class = "";
        this.arrayStatus[2].class = "";
        this.arrayStatus[3].class = "";

        this.arrayStatus[0].style = "100";
        this.arrayStatus[1].style = "100";
        this.arrayStatus[2].style = "100";
        this.arrayStatus[3].style = "100";

        break;
    }
  }


}
