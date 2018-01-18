import { Component, OnInit, Input } from '@angular/core';
import { Alert, AlertType } from '../../../Models/alert';

@Component({
  selector: 'app-alert-inline',
  templateUrl: './alert-inline.component.html',
  styleUrls: ['./alert-inline.component.css']
})
export class AlertInlineComponent implements OnInit {
  @Input() public alertDetails: Alert;
  constructor() { }

  ngOnInit() {
    if (this.alertDetails.showMsg) {
      setTimeout(() => this.hideAlert(), 5000)
    }
  }

  hideAlert() {
    this.alertDetails.showMsg = false;
  }

}
