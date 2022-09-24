import { MatDialog, MatDialogRef } from "@angular/material/dialog";
import { Injectable } from "@angular/core";
import { ConfirmDialogComponent } from "../shared/confirm-dialog/confirm-dialog.component";
import { InfoDialogComponent } from "../shared/info-dialog/info-dialog.component";

@Injectable({
    providedIn: 'root'
  })
export class DialogService {

    constructor(private dialog: MatDialog) {
    }

    infoDialog(titleText: string, contentText: string, actionButtonLabelText: string ,
      closeAction: () => void = null): MatDialogRef<any> {
      const dialogRef = this.dialog.open(
          InfoDialogComponent,
          {
              data: {
                  title: titleText,
                  content: contentText,
                  actionButtonLabel: actionButtonLabelText
                   }, disableClose: false });
          dialogRef.afterClosed().subscribe(() => {
                if (closeAction)
                  closeAction();
          });
          return dialogRef;
      }

    confirmDialog(titleText: string, contentText: string, denyActionButtonLabelText: string,confirmActionButtonLabelText: string ,
      confirmAction: () => void = null, denyAction: () => void = null, closeAction: () => void = null): MatDialogRef<any> {
      const dialogRef = this.dialog.open(
        ConfirmDialogComponent,
        {
            data: {
                title: titleText,
                content: contentText,
                confirmActionButtonLabel: confirmActionButtonLabelText,
                denyActionButtonLabel: denyActionButtonLabelText
                 }, disableClose: true });
          dialogRef.afterClosed().subscribe(result => {
              if (result)
              {
                  if (result.confirmed && confirmAction)
                    confirmAction();
                  if (!result.confirmed && denyAction)
                    denyAction();
              }
              if (closeAction)
                closeAction();
        });
        return dialogRef;
    }
}
