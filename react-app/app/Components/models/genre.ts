import {Game} from './game'
import { UUID } from 'crypto';

export type Genre = {
    genreID: UUID;
    name: string;
    description: string;

    // علاقة Many-to-Many مع Game
    games?: Game[];
};