import { useEffect, useState } from "react";
import styles from "./page.module.css";
import Image from "next/image";

import { Game } from "@/app/Components/models/game";

type prop = {
  gameID: number;
};

function GameDetails(prop: prop) {
  const [game, setGame] = useState<Game>();

  useEffect(() => {
    fetch("https://10.0.0.10:7165/api/Games/GetGame", {
      method: "POST",
      headers: {
        "Content-Type": "application/json", // 👈 مهم جداً
      },
      body: JSON.stringify(prop.gameID),
    })
      .then((res) => res.json())
      .then((data) => setGame(data))
      .catch((err) => console.error(`Error: ${err}`));
  }, []);

  const coverImage = game?.medias?.find(
    (media) => media.mediaType === "Cover"
  )?.mediaPath;

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
            src={
              game.medias?.filter((media) => media.mediaType === "Cover")[0]
                ?.mediaPath ?? ""
            }
            width={640}
            height={360}
            alt="game cover"
            priority
          />
        )}
        <div className={styles.MediaBrowser}></div>
      </div>
    </div>
  );
}

export default GameDetails;
