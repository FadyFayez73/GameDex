import {Game} from './game'
import { UUID } from 'crypto';

export type Media = {
    mediaID: UUID;
    mediaType: string;
    mediaPath: string;

    // علاقة Many-to-One مع Game
    gameID?: UUID;
    game?: Game;
};