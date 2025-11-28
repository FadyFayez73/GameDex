"use client";


import Image from "next/image";
import GameDetails from "@/components/features/GameDetails/GameDetails";
// import Modal from "react-modal";

//Models
import { GameForDisplay } from "@/components/models/GameFoDisplay";
import { useContext, useEffect, useState } from "react";
import { ControlContext } from "@/components/contexts/ControlContext";

// Componants
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";
import { Label } from "@/components/ui/label";

type Param = {
  game: GameForDisplay;
};

function ListComponent({ game }: Param) {
  const [openDetails, setOpenDetails] = useState(false);
  const { setGameID } = useContext(ControlContext);
  const coverImage = game.coverUrl ?? "";

  // useEffect(() => {
  //   // يتأكد إن الكود يتنفذ بعد ما يتعمل Mount
  //   Modal.setAppElement("body"); // أو استخدم 'body' بدل '#root' لو مش ضامن وجوده
  // }, []);

  useEffect(() => {
    console.log("مسا مسا");
  }, [openDetails]);

  const click = () => {
    setGameID(game.gameID);
  };

  return (
    <>
      <div
        onClick={() => click()}
        onDoubleClick={() => setOpenDetails(true)}
        className="flex-shrink-0 flex border rounded-sm flex-row p-0 w-full h-auto overflow-hidden gap-1"
      >
        {coverImage && (
          <Image
            className="w-[300px] h-auto"
            src={coverImage ?? ""}
            width={1920}
            height={1080}
            alt="game cover"
            priority
          />
        )}
        <div className="flex flex-col p-1 gap-1 w-full h-full">
          <h4 className="w-full text-lg font-bold font-sans">{game.name}</h4>
          <div className="flex flex-row gap-2 text-sm">
            <label className="text-gray-500">Development Company:</label>
            <span className="">Company</span>
          </div>
          <div className="flex flex-row gap-2 text-sm">
            <label className="text-gray-500">Price:</label>
            <span className="flex flex-row">
              {game.steamPrices}
              <div className="text-gray-400">$</div>
            </span>
          </div>
          <div className="flex flex-col justify-center content-start ">
            <Label className="text-gray-500 text-sm">Genre:</Label>
            <div className="flex flex-row w-full gap-2 p-1 flex-wrap">
              {game.genres.map((genre) => (
                <div
                  key={genre}
                  className="p-0.5 text-xs bg-gray-800 text-gray-200 rounded"
                >
                  {genre}
                </div>
              ))}
            </div>
          </div>
        </div>
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

export default ListComponent;
