import {Game} from './game'
import { UUID } from 'crypto';

export type Company = {
    companyID: UUID;
    name: string;
    description: string;
    companyType: number;

    // علاقة Many-to-Many مع Game
    games?: Game[];
};