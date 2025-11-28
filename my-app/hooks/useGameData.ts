import { useState, useEffect } from "react";
import { Game } from "@/components/models/game";
import { Media } from "@/components/models/media";
import { Genre } from "@/components/models/genre";
import { apiUrl } from "@/app/api-config";

interface GameData {
    game: Game | undefined;
    medias: Media[] | undefined;
    genres: Genre[] | undefined;
    loading: boolean;
    error: unknown;
}

export function useGameData(gameId: string): GameData {
    const [game, setGame] = useState<Game>();
    const [medias, setMedias] = useState<Media[]>();
    const [genres, setGenres] = useState<Genre[]>();
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<unknown>(null);

    useEffect(() => {
        if (!gameId) return;

        setLoading(true);
        setError(null);

        const fetchData = async () => {
            try {
                const [gameRes, mediaRes, genreRes] = await Promise.all([
                    fetch(`${apiUrl}/Games/Details/${gameId}`),
                    fetch(`${apiUrl}/Medias/by-game/${gameId}`),
                    fetch(`${apiUrl}/Genres/by-game/${gameId}`),
                ]);

                if (!gameRes.ok) throw new Error("Failed to fetch game details");
                if (!mediaRes.ok) throw new Error("Failed to fetch media");
                if (!genreRes.ok) throw new Error("Failed to fetch genres");

                const gameData = await gameRes.json();
                const mediaData = await mediaRes.json();
                const genreData = await genreRes.json();

                setGame(gameData);
                setMedias(mediaData);
                setGenres(genreData);
            } catch (err) {
                console.error(err);
                setError(err);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, [gameId]);

    return { game, medias, genres, loading, error };
}
