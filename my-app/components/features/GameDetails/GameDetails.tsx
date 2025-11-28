"use client";

import React, { useMemo } from "react";
import Image from "next/image";
import { Swiper, SwiperSlide } from "swiper/react";
import { Pagination, Navigation } from "swiper/modules";

import "swiper/css";
import "swiper/css/pagination";
import "swiper/css/navigation";
import "./swiperStyle.css";

import { useGameData } from "@/hooks/useGameData";

interface GameDetailsProps {
  gameID: string;
}

function GameDetails({ gameID }: GameDetailsProps) {
  const { game, medias, genres, loading, error } = useGameData(gameID);

  const coverImage = useMemo(() => {
    return medias?.find((media) => media.mediaType === "Cover")?.mediaPath ?? "";
  }, [medias]);

  if (loading) {
    return <div className="w-full h-full flex items-center justify-center text-white">Loading...</div>;
  }

  if (error) {
    return <div className="w-full h-full flex items-center justify-center text-red-500">Error loading game details</div>;
  }

  return (
    <div className="w-full h-full flex flex-col md:flex-row bg-background text-foreground overflow-hidden">
      {/* Main Content */}
      <div className="w-full h-full flex flex-col items-center overflow-y-auto">
        {/* Media Section */}
        <div className="w-full max-h-[500px] flex flex-col md:flex-row items-center gap-4 p-4 overflow-hidden shrink-0">
          {coverImage && (
            <div className="w-full md:w-[350px] h-full shrink-0 relative aspect-video md:aspect-auto rounded-lg overflow-hidden shadow-lg">
              <Image
                className="object-cover"
                src={coverImage}
                fill
                alt="game cover"
                priority
              />
            </div>
          )}

          <div className="w-full h-full flex-1 relative rounded-lg overflow-hidden shadow-lg min-w-0">
            <Swiper
              slidesPerView={1}
              spaceBetween={30}
              loop={true}
              pagination={{ clickable: true }}
              navigation={true}
              modules={[Pagination, Navigation]}
              className="w-full h-full"
            >
              {coverImage && (
                <SwiperSlide className="w-full h-full relative">
                  <Image
                    src={coverImage}
                    fill
                    className="object-cover"
                    alt="game cover"
                    priority
                  />
                </SwiperSlide>
              )}
              {/* Example video slide - replace with actual media logic if available */}
              <SwiperSlide className="w-full h-full flex items-center justify-center bg-black">
                <video
                  className="w-full h-full object-contain"
                  autoPlay
                  controls
                  muted
                  controlsList="nodownload noremoteplayback nopictureinpicture"
                  disablePictureInPicture
                  onContextMenu={(e) => e.preventDefault()}
                >
                  <source src="/media.mp4" type="video/mp4" />
                </video>
              </SwiperSlide>
            </Swiper>
          </div>
        </div>

        {/* Details Section */}
        <div className="w-full flex flex-col gap-4 p-4 max-w-4xl">
          {/* Game Name */}
          <div className="text-2xl font-bold text-primary">
            <h2>{game?.name ?? "No Game Name"}</h2>
          </div>

          {/* Description */}
          <div className="bg-card text-card-foreground shadow-md rounded-md p-4">
            <p className="leading-relaxed">{game?.gameDescription ?? "No description available."}</p>
          </div>

          {/* Genres */}
          <div className="bg-card text-card-foreground shadow-md rounded-md p-4 flex flex-col gap-2">
            <h4 className="font-semibold text-lg">Genres</h4>
            <div className="flex flex-row gap-2 flex-wrap">
              {genres && genres.length > 0 ? (
                genres.map((genre) => (
                  <div
                    key={genre.genreID}
                    className="px-3 py-1 bg-secondary text-secondary-foreground rounded-full text-sm font-medium"
                  >
                    {genre.name}
                  </div>
                ))
              ) : (
                <p className="text-muted-foreground">The game has no genres</p>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default GameDetails;
