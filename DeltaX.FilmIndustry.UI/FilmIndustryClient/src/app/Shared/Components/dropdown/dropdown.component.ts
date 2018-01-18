import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { Dropdown } from '../../../Models/dropdown';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css']
})
export class DropdownComponent implements OnInit {
  public selectedDropdown: Dropdown;
  @Input() public dropdownValues: Dropdown[];
  @Input() public dropdownClass: string;
  @Input() public defaultSelectedId: number;
  @Output() public selectedValue: EventEmitter<Dropdown> = new EventEmitter<Dropdown>()
  constructor() { }

  ngOnInit() {
    this.selectDefaultValue();
  }

  selectDefaultValue(): void {
    if (this.defaultSelectedId != null) {
      this.selectedDropdown = this.dropdownValues.find((dv: Dropdown) => dv.id == this.defaultSelectedId);
    }
  }

  notifySelectedDropdown(selectedId: number) {
    this.selectedDropdown = this.dropdownValues.filter(x => x.id === selectedId)[0];
    this.selectedValue.emit(this.selectedDropdown);
  }

}
