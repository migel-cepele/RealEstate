import { ApplicationState } from "./application/application.state";
import { HouseState } from "./house/house.state";

//this file contains app state

export interface AppState {
  houses: HouseState;
  applications: ApplicationState
    // Add other state slices here as needed
}