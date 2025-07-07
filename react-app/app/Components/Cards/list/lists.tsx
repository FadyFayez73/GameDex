import styles from "./lists.module.css";
import List from "./Components/List-Default";
import { Game } from "../../models/game";
import Loader from "../../Loader/Loader";

type props = {
  games: Game[];
}

function ListContener(props:props) {
  return (
    <div className={styles.Content}>
      {props.games.length === 0 ? (
        <Loader />
      ) : (
        props.games.map((game) => <List key={game.gameID} game={game} />)
      )}
    </div>
  );
}

export default ListContener;
