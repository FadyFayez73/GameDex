"use client";

import styles from "./page.module.scss";
import Image from "next/image";
import GameDetails from "@/app/GameDetailsPage/page";
import Modal from "react-modal";

//Models
import { Game } from "@/app/Components/models/game";
import { useEffect, useState } from "react";

type Param = {
  game: Game;
};

function DefaultCard(param: Param) {
  const [gameDetails, setGameDetails] = useState(false);
  const [modalIsOpen, setModalIsOpen] = useState(false);

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
  return (
    <div
      onClick={() => setModalIsOpen(true)}
      className={styles.Card}
      key={param.game.gameID}
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
      <Modal
        isOpen={modalIsOpen}
        onRequestClose={() => setModalIsOpen(false)}
        className={styles.Modal}
      >
        <div className={styles.backButton}>
          <button
            onClick={(e) => {
              e.stopPropagation(); // 👈 دي تمنع الكليك يوصل للكارت الأب

              console.log("closing modal");
              setModalIsOpen(false);
            }}
          >
            X
          </button>
        </div>
        <div className={styles.ModalBody}></div>
        <GameDetails gameID={param.game.gameID} />
      </Modal>
    </div>
  );
}

export default DefaultCard;
