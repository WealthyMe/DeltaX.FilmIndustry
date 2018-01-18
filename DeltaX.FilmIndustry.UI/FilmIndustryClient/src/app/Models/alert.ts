export class Alert {
  public showMsg: boolean;
  public alertType: AlertType;
  public msgToDisplay: string;

}



export enum AlertType {
    Error = "alert-danger",
    Warning = "alert-warning",
    Success = "alert-success"
  }
