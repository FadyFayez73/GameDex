import { Media } from './media'
import { Genre } from './genre'
import { Company } from './company'

export type Game = {
    gameID: number;
    name: string;
    patch: string;
    gamePath: string;
    yearOfRelease: string;
    pgRating: string;
    gameDescription: string;
    gameEngine: string;
    orderOfFranchise: string;
    linkForCrack: string;
    criticsRating: number;
    playersRating: number;
    userRating: number;
    steamPrices: number;
    actualGameSize: string;
    gameFiles: string;
    hoursToComplete: number;
    playerHours: number;
    storyPlace: string;

    // علاقات Many-to-Many
    companies?: Company[];
    medias?: Media[];
    genres?: Genre[];
};
