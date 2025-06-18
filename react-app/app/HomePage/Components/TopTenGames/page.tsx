'use client';

import { useEffect, useState } from 'react';
import styles from './page.module.css';
import DefaultCard from './Components/Card-Default'

type Game = {
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

type Media = {
    mediaID: number;
    mediaType: string;
    mediaPath: string;

    // علاقة Many-to-One مع Game
    gameID?: number;
    game?: Game;
};

type Genre = {
    genreID: number;
    name: string;
    description: string;

    // علاقة Many-to-Many مع Game
    games?: Game[];
};

type Company = {
    companyID: number;
    name: string;
    description: string;
    companyType: number;

    // علاقة Many-to-Many مع Game
    games?: Game[];
};


function TopTenGames(){
    const [Games, setGames] = useState<Game[]>([])
    
    useEffect(() => {
        fetch('https://localhost:7165/api/Games/top-ten')
        .then(res => res.json())
        .then(data => setGames(data))
        .catch(err => console.error("❌ خطأ أثناء جلب البيانات:", err));
    }, []);

    return (
        <div className={styles.TopGames}>
            <div className={styles.Header}>
                <h3>Top {Games.length} Games</h3>
            </div>
            <div className={styles.HerBody}>
                {Games.length === 0 ? <p>Loading...</p> : Games.map(game => (
                    <DefaultCard key={game.gameID} game={game}/>
                ))}
            </div>
        </div>
    );
}

export default TopTenGames;