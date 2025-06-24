'use client';

import { HTMLElementType, useEffect, useRef, useState } from 'react';
import styles from './page.module.css';
import DefaultCard from '../../../Components/Cards/Card-Default'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faGamepad, faDatabase, faList, faVcard } from "@fortawesome/free-solid-svg-icons";

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


function Main(){
    const [Games, setGames] = useState<Game[]>([]);
    const [Mod, setMod] = useState<string>("defualtCard");
    const Radio = useRef<HTMLElementType>(null);
    
    useEffect(() => {
        fetch('https://10.0.0.10:7165/api/Library/GetAllForDisplay')
        .then(res => res.json())
        .then(data => setGames(data))
        .catch(err => console.error("❌ خطأ أثناء جلب البيانات:", err));
    }, []);

    const [test, setTest] = useState('create')

    useEffect(() => {
        console.log(test);
    }, [test])

    useEffect(() => {

        console.log(Mod);
    }, [Mod])

    return (
        <div className={styles.Content}>
            <div className={styles.Header}>
                <div className={styles.AppLogo}>
                    <FontAwesomeIcon className={styles.Logo} icon={faGamepad}/>
                    <div>
                        <div>GameDex - للعلق صلاح</div>
                        <ul>
                            <li><FontAwesomeIcon icon={faGamepad}/> <span>{Games.length}</span></li>
                            <li><FontAwesomeIcon icon={faDatabase}/> <span>12 MB</span></li>
                        </ul>
                    </div>
                </div>

                <div className={styles.Controls}>
                    <button className={styles.btnCreate} onClick={() => setTest('Create')}>Create</button>
                    <button className={styles.btnUpdate} onClick={() => setTest('Update')}>Update</button>
                    <button className={styles.btnDelete} onClick={() => setTest('Delete')}>Delete</button>
                </div>
            </div>
            <div className={styles.PageMossContainer}>
                <ul>
                    <li>
                        <input
                            type="radio"
                            name="option"
                            checked={Mod === "defualtCard"}
                            onChange={() => setMod("defualtCard")}
                            />
                        <span 
                            className={
                                Mod === "defualtCard"
                                ? `${styles.radioMark} ${styles.active}`
                                : styles.radioMark}>
                                <FontAwesomeIcon icon={faVcard} />
                        </span>
                    </li>
                    <li>
                        <input
                            type="radio"
                            name="option"
                            checked={Mod === "listCard"}
                            onChange={() => setMod("listCard")}
                            />
                        <span 
                            className={
                                Mod === "listCard"
                                ? `${styles.radioMark} ${styles.active}`
                                : styles.radioMark}>
                                    <FontAwesomeIcon icon={faList} />
                        </span>
                    </li>
                </ul>
            </div>
            <div className={styles.HerBody}>
                {Games.length === 0 ? <p>Loading...</p> : Games.map(game => (
                    <DefaultCard key={game.gameID} game={game}/>
                ))}
            </div>
        </div>
    );
}

export default Main;