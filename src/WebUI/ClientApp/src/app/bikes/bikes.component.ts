import { Component, OnInit } from '@angular/core';
import {BikesClient, BikeDto} from "../web-api-client";

@Component({
  selector: 'app-bikes',
  templateUrl: './bikes.component.html',
  styles: [
  ]
})
export class BikesComponent implements OnInit {
  bikes: BikeDto[];
  constructor(private bikesClient: BikesClient) { }

  ngOnInit(): void {

    this.bikesClient.get().subscribe(
        result => {
          this.bikes = result.bikes;
        },
        error => console.error(error)
    );
  }
}
