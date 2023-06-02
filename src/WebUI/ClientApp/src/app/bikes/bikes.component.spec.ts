import {async, ComponentFixture, TestBed} from '@angular/core/testing';

import { BikesComponent } from './bikes.component';
import {BikeDto, BikesClient} from "../web-api-client";

describe('BikesComponent', () => {
  let component: BikesComponent;
  let fixture: ComponentFixture<BikesComponent>;
  let mockBikesClient = { get: () => { return {subscribe: () => { return {bikes:[{id: 1, model: 'Rockhopper'}]}} } } };

  beforeEach(async () => {
    
    await TestBed.configureTestingModule({
      declarations: [ BikesComponent ],
      providers: [
        { provide: BikesClient, useValue: mockBikesClient }
      ]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BikesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  
  it('should display correct page title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Bikes');
  }));

  it('should display bikes list', async(() => {
    component.bikes = [new BikeDto({id: 1, model: "Rockhopper", frameSize: 19, price: 299.99})]
    fixture.detectChanges()
    const titleText = fixture.nativeElement.querySelector('h2').textContent;
    expect(titleText).toEqual('Current Bikes');
  }));
});
