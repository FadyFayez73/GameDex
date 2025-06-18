'use client';

import styles from './page.module.css'

type Param = {
    game:Game;
}

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

function DefaultCard(param: Param){
    return(
    <div className={styles.Card} key={param.game.gameID}>
        <img src={param.game.medias?.filter(media => 
        media.mediaType === "Cover")[0]?.mediaPath} alt="game cover" />
        <div className={styles.CradBody}>
            <h4>{param.game.name}</h4>
            <p>{param.game.companies?.map(c => c.name).join(" And ")}</p>
            <div className={styles.Items}>
                <div className={styles.UserRate}>
                    {param.game.userRating}
                </div>
                <div className={styles.Price}>
                    {param.game.steamPrices}
                </div>
            </div>
            <div className={styles.Genres}>
                <ul>
                    {param.game.genres?.map(g => (<li>{g.name}</li>))}
                </ul>
            </div>
        </div>
    </div>


    )
}

export default DefaultCard;