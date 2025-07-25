
import { UUID } from 'crypto';

export type Game = {
    gameID: UUID;
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
};
