"use client";

import styles from "./cards.module.css";
import Card from "./Components/Card-Default";
import { GameForDisplay } from "../../models/GameFoDisplay";
import Loader from "../../Loader/Loader";

type PageProps = {
  games: GameForDisplay[]; // أو لو جاية من params مثلاً، وضّحها أكتر
};

function CardContener({ games }: PageProps) {
  return (
    <div className={styles.Content}>
      {games?.length === 0 ? (
        <Loader />
      ) : (
        games?.map((game) => <Card key={game.gameID} game={game} />)
      )}
    </div>
  );
}

export default CardContener;
