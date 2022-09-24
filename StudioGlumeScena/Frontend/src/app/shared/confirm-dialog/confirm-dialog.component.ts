import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: 'course-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent {
  title: string;
  content: string;
  denyActionButtonLabel: string;
  confirmActionButtonLabel: string;

  constructor(
    private dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) { title, content, denyActionButtonLabel, confirmActionButtonLabel }) {
    this.title = title;
    this.content = content;
    this.denyActionButtonLabel = denyActionButtonLabel;
    this.confirmActionButtonLabel = confirmActionButtonLabel;
  }
}
