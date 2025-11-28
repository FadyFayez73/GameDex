import { Genre } from "@/components/models/genre";

// models/filterModel.ts
import { apiUrl } from "@/app/api-config";
import { useEffect, useState } from "react";

export type FilterModel = {
  checkboxes: Record<string, string[]>;
  range: {
    price: { min: number; max: number };
    size: { min: number; max: number };
  };
  sortBy: string;
};

// 👇 ده الـ static default
export const defaultFilterModel: FilterModel = {
  checkboxes: {
    genres: [], // placeholder لحد ما نجيبها من الـ API
    platforms: ["PC", "PlayStation 3", "PlayStation 4", "Xbox", "Switch"],
    tags: ["Multiplayer", "Single Player", "Controller Support"],
  },
  range: {
    price: { min: 0, max: 100 },
    size: { min: 0, max: 100 },
  },
  sortBy: "name",
};

// 👇 function بتجيب الـgenres من الـAPI
export const fetchGenres = async (): Promise<string[]> => {
  try {
    const res = await fetch(`${apiUrl}/Genres`); // ✨ غيّر الـURL حسب API عندك
    if (!res.ok) {
      console.error("Error fetching genres:", await res.text());
      return [];
    }
    const data = await res.json();
    // لو API بيرجع array من objects اعمل map للـname
    return data.map((g: Genre) => g.name ?? "");
  } catch (err) {
    console.error("Exception fetching genres:", err);
    return [];
  }
};

// 👇 hook بيرجعلك الموديل مع الـgenres محملة
export const useFilterModel = () => {
  const [filterModel, setFilterModel] = useState<FilterModel>(defaultFilterModel);

  useEffect(() => {
    const loadGenres = async () => {
      const genres = await fetchGenres();
      setFilterModel((prev) => ({
        ...prev,
        checkboxes: {
          ...prev.checkboxes,
          genres,
        },
      }));
    };

    loadGenres();
  }, []);

  return filterModel;
};
