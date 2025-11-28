import {Game} from './game'

export type Genre = {
    genreID: string;
    name: string;
    description: string;

    // علاقة Many-to-Many مع Game
    games?: Game[];
};