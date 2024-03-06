/* eslint-disable @angular-eslint/no-output-on-prefix */
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PositionModel } from 'src/Model/PositionModel';
import { PositionServiceService } from 'src/Services/Position/PositionService.service';

@Component({
  selector: 'app-position-update',
  templateUrl: './position-update.component.html',
  styleUrls: ['./position-update.component.scss']
})
export class PositionUpdateComponent implements OnInit {
  constructor(private Service:PositionServiceService,private router : Router,private route:ActivatedRoute){}
  @Input() selectedID : string
  @Output() onUpdate: EventEmitter<string> =   new EventEmitter();
  @Output() onSuccess: EventEmitter<void> = new EventEmitter();
  id:string
  data : PositionModel


  ngOnInit(): void {
    this.GetPositionID()
  }

  GetPositionID(){
    this.Service.GetPositionByID(this.selectedID).subscribe((res)=>{
      this.data = res
    })
  }


  Update(position : PositionModel){
    this.onUpdate.emit(this.selectedID)
    this.Service.UpdatePosition(this.selectedID,position).subscribe((res)=>{
      if(res){
        alert('Success')
          setTimeout(() => {
            this.onSuccess.emit()
          }, 5);
          window.location.reload()
      }
      else{
        alert('Fail')
        setTimeout(() => {
          this.onSuccess.emit()
        }, 5);
      }
    })
  }

}
