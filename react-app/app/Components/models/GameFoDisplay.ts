import { Media } from './media'
import { Genre } from './genre'
import { Company } from './company'

export type GameForDisplay = {
  gameID: string;
  name: string;
  pgRating: string;
  userRating: number;
  steamPrices: number;
  coverUrl: string;
  genres: string[];      // باين إنها لسة فاضية بس هتبقى array من string
  platforms: string[];   // نفس الكلام هنا
};
