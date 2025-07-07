import {Game} from './game'

export type Genre = {
    genreID: number;
    name: string;
    description: string;

    // علاقة Many-to-Many مع Game
    games?: Game[];
};