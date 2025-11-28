"use client";

import Card from "./components/card";
import { GameForDisplay } from "@/components/models/GameFoDisplay";
import Loader from "@/components/loaders/Loader";

import NotFound from "@/components/loaders/notFoundState/NotFound";

type PageProps = {
  games: GameForDisplay[]; // أو لو جاية من params مثلاً، وضّحها أكتر
  isNotFound: boolean;
};

function CardContener({ games, isNotFound }: PageProps) {

  const statHandler = () => {
    if (isNotFound) return <NotFound />;
    else return <Loader />;
  };

  return (
    <div className="w-full h-full flex flex-row flex-wrap content-start p-2 gap-2 overflow-auto scrollbar-custom">
      {games?.length === 0
        ? statHandler()
        : games?.map((game) => <Card key={game.gameID} game={game} />)}
    </div>
  );
}

export default CardContener;
