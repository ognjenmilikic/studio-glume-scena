import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: 'info-dialog',
  templateUrl: './info-dialog.component.html',
  styleUrls: ['./info-dialog.component.scss']
})
export class InfoDialogComponent {
  title: string;
  content: string;
  actionButtonLabel: string;

  constructor(
    private dialogRef: MatDialogRef<InfoDialogComponent>,
    @Inject(MAT_DIALOG_DATA) { title, content, actionButtonLabel }) {
    this.title = title;
    this.content = content;
    this.actionButtonLabel = actionButtonLabel;
  }
}
