import { Trackpoint } from '../../trackpoints/shared/trackpoint.model'

export class Trail {
    id: number;
    name: string;
    description?: string;
    duration?: number;
    trackpoints: Trackpoint[];
}