import { UUID } from 'crypto';

export type GameForDisplay = {
  gameID: UUID;
  name: string;
  pgRating: string;
  userRating: number;
  steamPrices: number;
  coverUrl: string;
  genres: string[];      // باين إنها لسة فاضية بس هتبقى array من string
  platforms: string[];   // نفس الكلام هنا
};
