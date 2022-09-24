import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-upis-dialog',
  templateUrl: './upis-dialog.component.html',
  styleUrls: ['./upis-dialog.component.scss']
})
export class UpisDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private dialogRef: MatDialogRef<UpisDialogComponent>) { }

  ngOnInit(): void {
  }

  close(): void {
    this.dialogRef.close();
  }

}
