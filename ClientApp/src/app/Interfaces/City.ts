import {Province} from './Province';

export interface City {
    id: number;
    name: string;
    infected: number;
    dead: number;
    province: Province;
}