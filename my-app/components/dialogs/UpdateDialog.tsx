import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEdit } from "@fortawesome/free-solid-svg-icons";
import { useEffect, useState } from "react";

import { Game } from "@/components/models/game";

// Config
import { apiUrl } from "@/app/api-config";

type prop = {
  gameId: string;
};

export function UpdateDialog({ gameId }: prop) {
  const [game, setGame] = useState<Game | null>(null);

  useEffect(() => {
    fetch(`${apiUrl}/Games/Details/${gameId}`)
      .then((res) => res.json())
      .then((data) => setGame(data))
      .catch((err) => console.error(err));
  }, [gameId]);

  return (
    <Dialog>
      <form>
        <DialogTrigger asChild>
          <Button className="h-6 w-6 px-0 py-0 text-xs font-bold leading-none bg-transparent text-xs cursor-pointer text-gray-900 dark:text-gray-100 hover:bg-transparent hover:text-gray-700 hover:dark:text-gray-700">
            <FontAwesomeIcon icon={faEdit} />
          </Button>
        </DialogTrigger>
        <DialogContent className="sm:max-w-[450px] sm:max-h-[90vh]">
          <DialogHeader>
            <DialogTitle>Update Game</DialogTitle>
            <DialogDescription>
              Make changes to your profile here. Click save when youre done.
            </DialogDescription>
          </DialogHeader>
          <Label>{gameId}</Label>
          <div className="max-h-[60vh] overflow-y-auto pr-2 scrollbar-custom">
            <div className="grid gap-4">
              <div className="grid gap-3">
                <Label htmlFor="name-1">Name</Label>
                <Input id="name-1" name="name" defaultValue={`${game?.name}`} />
              </div>
              <div className="grid gap-3">
                <Label htmlFor="username-1">Username</Label>
                <Input
                  id="username-1"
                  name="username"
                  defaultValue="@peduarte"
                />
              </div>
              <div className="grid gap-3">
                <Label htmlFor="username-1">Set Game Cover</Label>
                <Input type="file" id="username-1" name="username" />
              </div>
              {/* محتوى إضافي لتجربة السكرول */}
              {Array.from({ length: 20 }).map((_, i) => (
                <div key={i} className="grid gap-3">
                  <Label htmlFor={`extra-${i}`}>Extra Field {i + 1}</Label>
                  <Input id={`extra-${i}`} name={`extra-${i}`} />
                </div>
              ))}
            </div>
          </div>

          <DialogFooter>
            <DialogClose asChild>
              <Button variant="outline">Cancel</Button>
            </DialogClose>
            <Button type="submit">Save Changes</Button>
          </DialogFooter>
        </DialogContent>
      </form>
    </Dialog>
  );
}
