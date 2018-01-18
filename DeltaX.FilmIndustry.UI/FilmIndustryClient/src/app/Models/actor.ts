import { Person } from "./person";
import { Gender } from "./gender";

export class Actor implements Person {
  public PersonID: number;
  public Name: string;
  public Gender: Gender;
  public DOB: Date;
  public Bio: string;
}
