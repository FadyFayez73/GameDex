import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";


import {
  faIcons,
} from "@fortawesome/free-solid-svg-icons";
import { Dispatch, SetStateAction, useEffect, useState } from "react";

// Models
import { Genre } from "@/components/models/genre";

// Config
import { apiUrl } from "@/app/api-config";
import GenresCreateDialog from "./components/genresCreateDialog";
import GenresDeleteDialog from "./components/genresDeleteDialog";
import GenresUpdatingDialog from "./components/genresUpdateDialog";

const GetGenres = async (
  setGenres: Dispatch<SetStateAction<Genre[] | null>>
) => {
  fetch(`${apiUrl}/Genres`)
    .then((res) => res.json())
    .then((data) => setGenres(data))
    .catch((err) => console.error(err));
};

export function GenresManagerDialog() {
  const [genres, setGenres] = useState<Genre[] | null>(null);

  useEffect(() => {
    GetGenres(setGenres);
  }, []);

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button className="h-6 w-6 px-0 py-0 text-xs font-bold leading-none bg-transparent text-xs cursor-pointer text-gray-900  dark:text-gray-100 hover:bg-transparent hover:text-gray-700 hover:dark:text-gray-700">
          <FontAwesomeIcon icon={faIcons} />
        </Button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[70%] sm:min-h-[90vh] sm:max-h-[90vh] lg:max-w-[50%] flex flex-col overflow-hidden">
        <DialogHeader>
          <DialogTitle>Genres Manager</DialogTitle>
          <DialogDescription>
            Make changes to your profile here. Click save when youre done.{" "}
            {genres ? `Genres: ${genres?.length}` : ""}
          </DialogDescription>
        </DialogHeader>
        {/* Creeat Button */}
        <div className="flex justify-end mb-4">
          <GenresCreateDialog
            onCreated={(genres) => {
              setGenres((prev) => (prev ? [genres, ...prev] : [genres]));
            }}
          />
        </div>
        {/* Content */}
        <div className="grid grid-cols-2 gap-4 mb-4 pr-2 overflow-y-auto scrollbar-custom">
          {genres?.map((genre) => (
            <div
              key={genre.genreID}
              className="flex flex-col items-center gap-1"
            >
              <div className="flex flex-col w-full">
                <span className="font-bold text-sm">{genre.name}</span>
                <span className="text-sm text-gray-500 text-wrap dark:text-gray-400">
                  {genre.description}
                </span>
              </div>
              <div className="w-full flex flex-row justify-end items-center text-sm">
                <GenresUpdatingDialog
                  genre={genre}
                  onUpdated={(updatedGenre) => {
                    setGenres((prev) =>
                      prev
                        ? prev.map((g) =>
                          g.genreID === updatedGenre.genreID
                            ? updatedGenre
                            : g
                        )
                        : prev
                    );
                  }}
                />

                <GenresDeleteDialog
                  genre={genre}
                  onDeleted={(deletedGenre) => {
                    setGenres((prev) =>
                      prev
                        ? prev.filter((g) => g.genreID !== deletedGenre.genreID)
                        : null
                    );
                  }}
                />
              </div>
            </div>
          ))}
        </div>
      </DialogContent>
    </Dialog>
  );
}
