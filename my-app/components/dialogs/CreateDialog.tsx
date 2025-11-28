import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAdd } from "@fortawesome/free-solid-svg-icons";

// Configs
import { apiUrl } from "@/app/api-config";
import { useRef, useState } from "react";

import Stepper, { Step } from "@/components/reactbits/Stepper/Stepper";

import Image from "next/image";

export function CreateDialog() {
  const formRef = useRef<HTMLFormElement>(null);
  const [gameName, setGameName] = useState<string>("");
  const [cover, setCover] = useState<File | null>(null);
  const [actualGameSize, setActualGameSize] = useState<string>("");
  const [criticsRating, setCriticsRating] = useState<string>("");
  const [gameEngine, setGameEngine] = useState<string>("");
  const [hoursToComplete, setHoursToComplete] = useState<string>("");
  const [pgRating, setPgRating] = useState<string>("");
  const [playerHours, setPlayerHours] = useState<string>("");
  const [steamPrices, setSteamPrices] = useState<string>("");
  const [userRating, setUserRating] = useState<string>("");

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault(); // لازم تمنع الافتراضي (refresh)
    console.log("📌 handleSubmit fired!");

    if (!cover) {
      alert("please choose the game cover first");
      return;
    }

    const formData = new FormData();
    formData.append("name", gameName);
    formData.append("cover", cover);

    const res = await fetch(`${apiUrl}/Games`, {
      method: "POST",
      headers: {
        Accept: "application/json",
        // "Content-Type": "application/json", // لا تستخدم هذا مع FormData
      },
      body: formData,
    });

    const data = await res.json();
    alert(data.message);
  };

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button className="h-6 w-6 px-0 py-0 text-xs font-bold leading-none bg-transparent text-xs cursor-pointer text-gray-900 dark:text-gray-100 hover:bg-transparent hover:text-gray-700 hover:dark:text-gray-700">
          <FontAwesomeIcon icon={faAdd} />
        </Button>
      </DialogTrigger>

      <DialogContent className="sm:max-w-[450px] sm:max-h-[90vh] h-auto">
        <form onSubmit={handleSubmit} ref={formRef}>
          <DialogHeader className="mb-5">
            <DialogTitle>Create New Game</DialogTitle>
            <DialogDescription>
              Make changes to your profile here. Click save when youre done.
            </DialogDescription>
          </DialogHeader>

          {/* Content */}
          <Stepper
            initialStep={1}
            onStepChange={(step) => {
              console.log(step);
            }}
            onFinalStepCompleted={() => {
              console.log("All steps completed!");
              formRef.current?.requestSubmit();
            }}
            backButtonText="Previous"
            backButtonProps={{ type: "button" }}
            nextButtonText="Next"
            nextButtonProps={{ type: "button" }}
            className="mb-0 w-full h-full"
            stepCircleContainerClassName="border-0 shadow-none!"
          >
            <Step>
              <div className="grid gap-4 py-4">
                <div className="grid gap-2">
                  <Label htmlFor="name">Name</Label>
                  <Input
                    id="name"
                    value={gameName}
                    onChange={(e) => setGameName(e.target.value)}
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="gameEngine">Game Engine</Label>
                  <Input
                    id="gameEngine"
                    value={gameEngine}
                    onChange={(e) => setGameEngine(e.target.value)}
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="hoursToComplete">Hours To Complete</Label>
                  <Input
                    id="hoursToComplete"
                    value={hoursToComplete}
                    onChange={(e) => setHoursToComplete(e.target.value)}
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="playerHours">Player Hours</Label>
                  <Input
                    id="playerHours"
                    value={playerHours}
                    onChange={(e) => setPlayerHours(e.target.value)}
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="steamPrices">Steam Prices</Label>
                  <Input
                    id="steamPrices"
                    value={steamPrices}
                    onChange={(e) => setSteamPrices(e.target.value)}
                  />
                </div>
              </div>
            </Step>
            <Step>
              <div className="grid gap-4 py-4">
                <div className="grid gap-2">
                  <Label htmlFor="actualGameSize">Actual Game Size</Label>
                  <Input
                    id="actualGameSize"
                    value={actualGameSize}
                    onChange={(e) => setActualGameSize(e.target.value)}
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="criticsRating">Critics Rating</Label>
                  <Input
                    id="criticsRating"
                    value={criticsRating}
                    onChange={(e) => setCriticsRating(e.target.value)}
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="userRating">User Rating</Label>
                  <Input
                    id="userRating"
                    value={userRating}
                    onChange={(e) => setUserRating(e.target.value)}
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="pgRating">PG Rating</Label>
                  <Input
                    id="pgRating"
                    value={pgRating}
                    onChange={(e) => setPgRating(e.target.value)}
                  />
                </div>
              </div>
            </Step>
            <Step>
              <div className="flex flex-col flex-1">
                <div className="grid gap-2">
                  <Label htmlFor="cover">Game Cover</Label>
                  <Input
                    type="file"
                    id="cover"
                    onChange={(e) => setCover(e.target.files?.[0] ?? null)}
                  />
                </div>
                {cover && (
                  <Image
                    className="w-full h-auto mt-2 rounded-md object-contain flex-1"
                    src={URL.createObjectURL(cover)}
                    width={300}
                    height={300}
                    alt="game cover preview"
                    unoptimized
                    onLoad={() => {
                      // ندي إشارة للـ Stepper أو نعمل reflow يدوي
                      window.dispatchEvent(new Event("resize"));
                    }}
                  />
                )}
              </div>
            </Step>
          </Stepper>
        </form>
      </DialogContent>
    </Dialog>
  );
}
