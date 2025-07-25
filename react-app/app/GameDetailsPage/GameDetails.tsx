"use client";

import React from "react";

import { useState } from "react";
import styles from "./GameDetails.module.css";
import Image from "next/image";

import { Game } from "@/app/Components/models/game";
import { Media } from "@/app/Components/models/media";

const GetGameFunction = (
  gameId: string,
  setGame: React.Dispatch<React.SetStateAction<Game | undefined>>
) => {
  fetch(`https://localhost:7165/api/Games/Details/${gameId}`)
    .then((res) => res.json())
    .then((data) => setGame(data))
    .catch((err) => console.error(`Error: ${err}`));
};

const GetMediasFunction = (
  gameId: string,
  setMedias: React.Dispatch<React.SetStateAction<Media[] | undefined>>
) => {
  fetch(`https://localhost:7165/api/Medias/ByGame/${gameId}`)
    .then((res) => res.json())
    .then((data) => setMedias(data))
    .catch((err) => console.error(`Error: ${err}`));
};

type prop = {
  gameID: string;
};

function GameDetails(prop: prop) {
  const [game, setGame] = useState<Game>();
  const [medias, setMedias] = useState<Media[]>();

  GetGameFunction(prop.gameID, setGame);
  GetMediasFunction(prop.gameID, setMedias);

  const coverImage =
    medias?.find((media) => media.mediaType === "Cover")?.mediaPath ??
    "none image";

  return (
    <div
      className={styles.Content}
      style={{
        backgroundImage: `linear-gradient(rgba(4,9,30,0.7), rgba(4,9,30,0.7)), url("${coverImage}")`,
        backgroundSize: "cover",
        backgroundPosition: "center",
        height: "100vh", // حسب ما تحب
      }}
    >
      <div className={styles.mediaBlock}>
        {coverImage && (
          <Image
            className={styles.GameCover}
            src={coverImage}
            width={640}
            height={360}
            alt="game cover"
            priority
          />
        )}
        <div className={styles.MediaBrowser}></div>
      </div>

      <h2>{game?.name ?? "No Game Name !"}</h2>
    </div>
  );
}

export default GameDetails;
