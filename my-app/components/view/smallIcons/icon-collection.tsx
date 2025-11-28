"use client";

import Icon from "./components/icon";
import { GameForDisplay } from "@/components/models/GameFoDisplay";
import Loader from "@/components/loaders/Loader";
import NotFound from "@/components/loaders/notFoundState/NotFound";

type PageProps = {
  games: GameForDisplay[]; // أو لو جاية من params مثلاً، وضّحها أكتر
  isNotFound: boolean;
};

function IconContener({ games, isNotFound }: PageProps) {

  const statHandler = () => {
    if (isNotFound) return <NotFound />;
    else return <Loader />;
  };

  return (
    <div className="w-full h-full flex flex-col flex-wrap content-start gap-2 pr-2 overflow-y-auto scrollbar-custom">
      {games?.length === 0 ? (
        statHandler()
      ) : (
        games?.map((game) => <Icon key={game.gameID} game={game} />)
      )}
    </div>
  );
}

export default IconContener;
