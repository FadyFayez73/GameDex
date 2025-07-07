"use client";

import styles from "./page.module.scss";
import Image from "next/image";
import Modal from "react-modal";

//Models
import { Game } from "@/app/Components/models/game";
import { useContext, useEffect, useState } from "react";
import { ControlContext } from "@/app/Components/Contexts/ControlContext";

type Param = {
  game: Game;
};

function DefaultList(param: Param) {
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const { gameID, setGameID } = useContext(ControlContext);
  const coverImage = param.game.medias?.find(
    (media) => media.mediaType === "Cover"
  )?.mediaPath;

  useEffect(() => {
    // يتأكد إن الكود يتنفذ بعد ما يتعمل Mount
    Modal.setAppElement("body"); // أو استخدم 'body' بدل '#root' لو مش ضامن وجوده
  }, []);

  useEffect(() => {
    console.log("مسا مسا");
  }, [modalIsOpen]);

  const click = () => {
    setGameID(param.game.gameID);
    console.log("Card is clicked!");
  };

  return (
    <div
      onClick={() => click()}
      onDoubleClick={() => setModalIsOpen(true)}
      className={styles.List}
      key={param.game.gameID}
      style={{
        boxShadow:
          gameID === param.game.gameID
            ? "0 0 20px 1px rgb(30,30,30)"
            : "0 0 10px 1px black",
        zIndex: 0,
      }}
    >
      {coverImage && (
        <Image
          className={styles.GameCover}
          src={
            param.game.medias?.filter((media) => media.mediaType === "Cover")[0]
              ?.mediaPath ?? ""
          }
          width={640}
          height={360}
          alt="game cover"
          priority
        />
      )}

      <div className={styles.CradBody}>
        <h4>{param.game.name}</h4>
        <p>{param.game.companies?.map((c) => c.name).join(" And ")}</p>
        <div className={styles.Items}>
          <div className={styles.UserRate}>{param.game.userRating}</div>
          <div className={styles.Price}>{param.game.steamPrices}</div>
        </div>
        <div className={styles.Genres}>
          <ul>
            {param.game.genres?.map((g) => (
              <li key={g.genreID}>{g.name}</li>
            ))}
          </ul>
        </div>
      </div>
    </div>
  );
}

export default DefaultList;
