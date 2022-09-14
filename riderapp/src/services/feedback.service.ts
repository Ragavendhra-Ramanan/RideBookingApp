import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { feedsmodel } from 'src/models/feedsmodel';
import { Observable } from 'rxjs';
import { FormsModule} from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  getUrl = "http://localhost:5000/api/v1.0/rideapp/feedback/all";
  postUrl = "http://localhost:5000/api/v1.0/rideapp/ramanan/feedback";

  constructor(private http: HttpClient) { }

  getFeeds(): Observable<feedsmodel[]> {
    return this.http.get<feedsmodel[]>(this.getUrl);
  }

  addFeeds(feed: feedsmodel): Observable<feedsmodel> {
    return this.http.post<feedsmodel>(this.postUrl, feed);
      
  }
  
}
