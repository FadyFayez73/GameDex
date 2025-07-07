export type FilterModel = {
  checkboxes: Record<string, string[]>; // ديناميكي بدل الثابت
  range: {
    price: { min: number; max: number };
    size: { min: number; max: number };
  };
  sortBy: string;
};

export const defaultFilterModel: FilterModel = {
  checkboxes: {
    genres: [
      "RPG",
      "Open World",
      "Story Rich",
      "Atmospheric",
      "Action-Adventure",
      "Hack and Slash",
      "Action",
      "Adventure",
    ],
    platforms: ["PC", "PlayStation 3", "PlayStation 4", "Xbox", "Switch"],
    tags: ["Multiplayer", "Single Player", "Controller Support"],
  },
  range: {
    price: { min: 0, max: 100 },
    size: { min: 0, max: 100 },
  },
  sortBy: "name",
};
