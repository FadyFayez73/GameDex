'use client';

import styles from './page.module.scss'
import Image from "next/image";

//Models
import { Game } from '@/app/Components/models/game';

type Param = {
    game:Game;
}

function DefaultList(param: Param){
    const coverImage = param.game.medias?.find(media => media.mediaType === "Cover")?.mediaPath;

    return(
    <div className={styles.List} key={param.game.gameID}>
        {coverImage && (
            <Image
                className={styles.GameCover}
                src={param.game.medias?.filter(media => media.mediaType === "Cover")[0]?.mediaPath ?? ""}
                width={640}
                height={360}
                alt="game cover"
                priority/>
        )}

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
                    {param.game.genres?.map(g => (<li key={g.genreID}>{g.name}</li>))}
                </ul>
            </div>
        </div>
    </div>


    )
}

export default DefaultList;