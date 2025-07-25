"use client";

import styles from "./page.module.scss";
import Image from "next/image";
import GameDetails from "@/app/GameDetailsPage/GameDetails";
import Modal from "react-modal";

//Models
import { GameForDisplay } from "@/app/Components/models/GameFoDisplay";
import { useContext, useEffect, useState } from "react";
import { ControlContext } from "@/app/Components/Contexts/ControlContext";

type Param = {
  game: GameForDisplay;
};

function DefaultCard(param: Param) {
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const { gameID, setGameID } = useContext(ControlContext);
  const coverImage = param.game.coverUrl ?? "";

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
      className={styles.Card}
      key={param.game.gameID}
      style={{
        borderBottom:
          gameID === param.game.gameID
            ? "1px solid gray"
            : "none",
        zIndex: 0,
      }}
    >
      {coverImage && (
        <Image
          className={styles.GameCover}
          src={
            coverImage ?? ""
          }
          width={640}
          height={360}
          alt="game cover"
          priority
        />
      )}

      <div className={styles.CradBody}>
        <h4>{param.game.name}</h4>
        {/* <p>{param.game.companies?.map((c) => c.name).join(" And ")}</p> */}
        <div className={styles.Items}>
          <div className={styles.UserRate}>{param.game.userRating}</div>
          <div className={styles.Price}>{param.game.steamPrices}</div>
        </div>
        <div className={styles.Genres}>
          {/* <ul>
            {param.game.genres?.map((g) => (
              <li key={g.genreID}>{g.name}</li>
            ))}
          </ul> */}
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
