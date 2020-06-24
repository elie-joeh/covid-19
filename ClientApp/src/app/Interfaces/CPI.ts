import { NumberValueAccessor } from '@angular/forms';

//TODO: add a geography type once geography interface is created
export interface CPI {
    id: number;
    reference_data: Date;
    dguid: string;
    vector_id: string;
    ppdg: string;
    coordinate: number;
    value: number;

    geo_name: string;
}