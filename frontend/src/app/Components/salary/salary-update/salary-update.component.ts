/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable @angular-eslint/no-output-on-prefix */
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SalaryModel } from 'src/Model/SalaryModel';
import { GeneralService } from 'src/Services/General/general.service';
import { SalaryService } from 'src/Services/Salary/salary.service';

@Component({
  selector: 'app-salary-update',
  templateUrl: './salary-update.component.html',
  styleUrls: ['./salary-update.component.scss']
})
export class SalaryUpdateComponent implements OnInit {
  constructor(private Service:SalaryService,private generalService : GeneralService,private router : Router,private route:ActivatedRoute){}
  @Input() selectedID : string
  @Output() onUpdate: EventEmitter<string> =   new EventEmitter();
  @Output() onSuccess: EventEmitter<void> = new EventEmitter();
  RanksData : any
  PositionsData : any
  selectedRankID : string
  selectedPositionID : string
  id:string
  data : SalaryModel


  ngOnInit(): void {
      this.GetRankAndPositionInfo()
  }

  GetSalaryID(){
    this.Service.GetSalaryByID(this.selectedID).subscribe((res)=>{
      this.data = res
    })
  }

  onRankchange(){
    console.log(this.selectedRankID)
    return this.selectedRankID
  }

  onPositionchange(){
    console.log(this.selectedPositionID)
    return this.selectedPositionID
  }

  GetRankAndPositionInfo(){
    this.generalService.GetRank().subscribe((resrank)=>{
      this.RanksData = resrank
    })
    this.generalService.GetPosition().subscribe((resposition)=>{
      this.PositionsData = resposition
    })
  }

  Update(salary : SalaryModel){
    console.log(salary)
    this.onUpdate.emit(this.selectedID)
    this.Service.UpdateSalary(this.selectedID,salary).subscribe((res)=>{
      if(res){
        alert('Success')
          setTimeout(() => {
            this.onSuccess.emit()
          }, 5);
          window.location.reload()
      }
      else {alert('Fail')
          setTimeout(() => {
            this.onSuccess.emit()
          }, 5)}
    })
  }
}
