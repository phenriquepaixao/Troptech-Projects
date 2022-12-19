import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IStatus } from 'src/app/IStatus';

@Component({
  selector: 'app-change-status',
  templateUrl: './change-status.component.html',
  styleUrls: ['./change-status.component.css']
})
export class ChangeStatusComponent implements OnInit {

  @Output()
  statusPedido: EventEmitter<string> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  handleChange(value: string) {
    this.statusPedido.emit(value);
  }

}
