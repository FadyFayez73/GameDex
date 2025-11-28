import { apiUrl } from "@/app/api-config";
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
import { useState } from "react";

import { Genre } from "@/components/models/genre";

type Props = {
  onCreated?: (newGenre: Genre) => void; // 👈 callback بيرجع للـDialog الأب
};

function GenresCreateDialog({ onCreated }: Props) {
  const [name, setName] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [open, setOpen] = useState(false); // 👈 تحكم في فتح/قفل المودال

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log("📌 handleSubmit fired!");

    const res = await fetch(`${apiUrl}/Genres`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        name: name,
        description: description,
      }),

    });

    if (res.ok) {
      const newGenre = await res.json();

      // نرجعه للأب
      if (onCreated) onCreated(newGenre);

      // نظّف الـinputs
      setName("");
      setDescription("");

      // قفل المودال
      setOpen(false);
    } else {
      const err = await res.text();
      console.error("Error creating genre: " + err);
    }
  };

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button className="bg-green-500 hover:bg-green-600 text-white px-4 py-2 rounded-md cursor-pointer">
          Create
        </Button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>Create Genre</DialogTitle>
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
            <Button type="submit">Create</Button>
          </DialogFooter>
        </form>
      </DialogContent>
    </Dialog>
  );
}

export default GenresCreateDialog;
