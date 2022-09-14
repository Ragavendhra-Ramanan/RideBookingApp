import { Component, OnInit } from '@angular/core';
import { feedsmodel } from 'src/models/feedsmodel';
import { FeedbackService } from 'src/services/feedback.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-feedbacks',
  templateUrl: './feedbacks.component.html',
  styleUrls: ['./feedbacks.component.css']
})
export class FeedbacksComponent implements OnInit {

  feedslist: feedsmodel[] = [];

  feeditems: feedsmodel = {
    id: '',
    userName: '',
    feed: ''
  }
  constructor(private feeds: FeedbackService) { }

  ngOnInit(): void {
    this.feeds.getFeeds().subscribe(response => {
      this.feedslist = response;
      console.log(response);})
  }



onSubmit(data:any){
      if(this.feeditems.id==='')
      {
        console.log('event triggered');
        
        console.log("Data: " + data);
        this.feeds.addFeeds(data).subscribe((result)=> {console.log(result)})
            
      }
  }

 }


