import { Producer } from "./producer";
import { Actor } from "./actor";

export class Movie {
  public MovieId: number;
  public Name: string;
  public YearOfRelease: number;
  public ImageId: number;
  public Producer: Producer;
  public Actors: Actor[];
  public Plot: string;
  constructor() {
    this.Actors = new Array<Actor>();
    this.Producer = new Producer();
  }
}
