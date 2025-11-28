import { apiUrl } from "@/app/api-config";
import { Genre } from "@/components/models/genre";
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

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEdit } from "@fortawesome/free-solid-svg-icons";

import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { useState } from "react";

type Props = {
  onUpdated?: (UpdateGenre: Genre) => void; // 👈 callback بيرجع للـDialog الأب
  genre: Genre;
};

function GenresUpdatingDialog({ onUpdated, genre }: Props) {
  const [name, setName] = useState<string>(genre.name);
  const [description, setDescription] = useState<string>(genre.description);
  const [open, setOpen] = useState(false); // 👈 تحكم في فتح/قفل المودال


  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log("📌 handleSubmit fired!");

    const res = await fetch(`${apiUrl}/Genres`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        genreId: genre.genreID,
        name: name,
        description: description,
      }),
    });

    if (res.ok) {
      // const state = await res.json(); // unused variable removed

      genre.name = name;
      genre.description = description;

      // نرجعه للأب
      if (onUpdated) onUpdated(genre);

      // نظّف الـinputs
      setName("");
      setDescription("");

      // قفل المودال
      setOpen(false);
    } else {
      const err = await res.text();
      console.error("Error updating genre: " + err);
    }
  };

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <button className="cursor-pointer">
          <FontAwesomeIcon icon={faEdit} />
        </button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>Update Genre</DialogTitle>
          <DialogDescription>
            Fill in the details below to create a new genre.
          </DialogDescription>
        </DialogHeader>

        <form onSubmit={handleSubmit}>
          <div className="flex flex-col gap-4 mb-4">
            <div className="grid gap-2">
              <Label htmlFor="name">Name</Label>
              <Input
                id="name"
                value={name}
                onChange={(e) => setName(e.target.value)}
              />
            </div>
            <div className="grid gap-2">
              <Label htmlFor="description">Description</Label>
              <Input
                id="description"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
              />
            </div>
          </div>

          <DialogFooter>
            <DialogClose asChild>
              <Button variant="outline">Cancel</Button>
            </DialogClose>
            <Button type="submit">Update</Button>
          </DialogFooter>
        </form>
      </DialogContent>
    </Dialog>
  );
}

export default GenresUpdatingDialog;
