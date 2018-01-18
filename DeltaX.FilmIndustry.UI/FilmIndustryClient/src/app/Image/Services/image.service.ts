import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class ImageService {
  private baseURL: string = location.origin;

  constructor(private _http: Http) { }

  getImageURL(imageId): string{
    return this.baseURL + '/api/Image/' + imageId;
  }

}
