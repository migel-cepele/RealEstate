import { ApplicationState } from "./application/application.state";
import { ClientState } from "./client/client.state";
import { HouseState } from "./house/house.state";
import { ItemState } from "./item/item.state";

//this file contains app state

export interface AppState {
  houses: HouseState;
  applications: ApplicationState
  items: ItemState;
  clients: ClientState;
    // Add other state slices here as needed
}