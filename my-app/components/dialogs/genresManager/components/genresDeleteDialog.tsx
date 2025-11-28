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
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";

type Props = {
  onDeleted?: (deletedGenre: Genre) => void; // 👈 callback بيرجع للـDialog الأب
  genre: Genre; // 👈 callback بيرجع للـDialog الأب
};

function GenresDeleteDialog({ onDeleted, genre }: Props) {
  const [open, setOpen] = useState(false); // 👈 تحكم في فتح/قفل المودال

  const handleSubmit = async () => {
    console.log("📌 handleSubmit fired!");

    const res = await fetch(`${apiUrl}/Genres/Delete/${genre.genreID}`, {
      method: "DELETE",
    });

    if (res.ok) {
      // نرجعه للأب
      if (onDeleted) onDeleted(genre);

      // قفل المودال
      setOpen(false);
    } else {
      const err = await res.text();
      console.error("Error deleting genre: " + err);
    }
  };

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <button className="cursor-pointer">
          <FontAwesomeIcon icon={faTrash} />
        </button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>Delete Genre</DialogTitle>
          <DialogDescription>
            Fill in the details below to create a new genre.
          </DialogDescription>
        </DialogHeader>
        <div className="text-center mb-4">
          Are you sure you want to delete the genre &quot;{genre.name}&quot;
        </div>
        <DialogFooter>
          <DialogClose asChild>
            <Button variant="outline">Cancel</Button>
          </DialogClose>
          <Button onClick={() => handleSubmit()}>Yes</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}

export default GenresDeleteDialog;
