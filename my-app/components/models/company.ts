import {Game} from './game'

export type Company = {
    companyId: string; // UUID
    name: string;
    description: string;
    companyType: number;

    // علاقة Many-to-Many مع Game
    games?: Game[];
};