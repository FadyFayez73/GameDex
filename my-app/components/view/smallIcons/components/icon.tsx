"use client";

import { useContext, useState } from "react";
import Image from "next/image";

//Models
import { GameForDisplay } from "@/components/models/GameFoDisplay";

// Contexts
import { ControlContext } from "@/components/contexts/ControlContext";

// Components
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";

// Pages
import GameDetails from "@/components/features/GameDetails/GameDetails";

function Icon({ game }: { game: GameForDisplay }) {
  const [openDetails, setOpenDetails] = useState(false);
  const { setGameID } = useContext(ControlContext);
  const coverImage = game.coverUrl ?? "";



  const click = () => {
    setGameID(game.gameID);
  };

  return (
    <>
      <div
        onClick={() => click()}
        onDoubleClick={() => setOpenDetails(true)}
        className="flex flex-row items-center h-[40px] gap-1"
      >
        {coverImage && (
          <Image
            className="w-[70px] h-auto"
            src={coverImage ?? ""}
            width={1920}
            height={1080}
            alt="game cover"
            priority
          />
        )}
        <div className="">{game.name}</div>
      </div>

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

export default Icon;
