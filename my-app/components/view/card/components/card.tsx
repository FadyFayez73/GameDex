"use client";
import { useContext, useState } from "react";
import Image from "next/image";

// Pages
import GameDetails from "@/components/features/GameDetails/GameDetails";
// import Modal from "react-modal";

//Models
import { GameForDisplay } from "@/components/models/GameFoDisplay";

// Contexts
import { ControlContext } from "@/components/contexts/ControlContext";

// components
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
  CardDescription,
} from "@/components/ui/card";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";

import ElectricBorder from "@/components/reactbits/ElectricBorder/ElectricBorder";

type Param = {
  game: GameForDisplay;
};

function CardComponent({ game }: Param) {
  const [openDetails, setOpenDetails] = useState(false);
  const { gameID, setGameID } = useContext(ControlContext);
  const coverImage = game.coverUrl ?? "";



  const click = () => {
    setGameID(game.gameID.toString());
  };

  const Selected = () => {
    return (
      <ElectricBorder
        color="#7df9ff"
        speed={1}
        chaos={0.5}
        thickness={12}
        style={{ borderRadius: 16 }}
        className="p-0 sm:w-full md:w-3/7 lg:w-2/9 xl:w-2/11 h-auto max-h-[fit-content] flex flex-col duration-300"
      >
        <Card
          onClick={() => click()}
          onDoubleClick={() => setOpenDetails(true)}
          className={`overflow-hidden gap-1 w-full h-full p-0
          duration-300`}
        >
          {coverImage && (
            <Image
              className="w-full"
              src={coverImage ?? ""}
              width={1920}
              height={1080}
              alt="game cover"
              priority
            />
          )}
          <CardHeader className="py-0 gap-1">
            <CardTitle>{game.name}</CardTitle>
            <CardDescription className="px-3">
              {game.steamPrices}$
            </CardDescription>
          </CardHeader>
          <CardContent className="p-1">
            <div className=""></div>
            <div className="flex flex-row gap-1 flex-wrap">
              {game.genres?.map((g) => (
                <div
                  key={g}
                  className="text-xs bg-gray-300 dark:text-gray-300 dark:bg-gray-900 font-bold p-1 rounded-md"
                >
                  {g}
                </div>
              ))}
            </div>
          </CardContent>
        </Card>
      </ElectricBorder>
    );
  };

  return (
    <>
      {gameID === game.gameID ? (
        Selected()
      ) : (
        <Card
          onClick={() => click()}
          onDoubleClick={() => setOpenDetails(true)}
          className={`p-0 sm:w-full md:w-3/7 lg:w-2/9 xl:w-2/11 h-auto max-h-[fit-content] overflow-hidden gap-1 
          duration-300`}
        >
          {coverImage && (
            <Image
              className="w-full"
              src={coverImage ?? ""}
              width={1920}
              height={1080}
              alt="game cover"
              priority
            />
          )}
          <CardHeader className="py-0 gap-1">
            <CardTitle>{game.name}</CardTitle>
            <CardDescription className="px-3">
              {game.steamPrices}$
            </CardDescription>
          </CardHeader>
          <CardContent className="p-1">
            <div className=""></div>
            <div className="flex flex-row gap-1 flex-wrap">
              {game.genres?.map((g) => (
                <div
                  key={g}
                  className="text-xs bg-gray-300 dark:text-gray-300 dark:bg-gray-900 font-bold p-1 rounded-md"
                >
                  {g}
                </div>
              ))}
            </div>
          </CardContent>
        </Card>
      )}

      <Dialog open={openDetails} onOpenChange={setOpenDetails}>
        <DialogContent className="sm:max-w-[96%] sm:max-h-[96%] transition-all duration-150 ease-out">
          <DialogHeader>
            <DialogTitle>Game Details</DialogTitle>
          </DialogHeader>
          <GameDetails gameID={game.gameID.toString()} />
        </DialogContent>
      </Dialog>
    </>
  );
}

export default CardComponent;
