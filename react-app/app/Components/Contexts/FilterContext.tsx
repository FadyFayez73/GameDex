'use client';

import { createContext, useState, ReactNode, Dispatch, SetStateAction } from "react";
import { FilterModel, defaultFilterModel } from "../models/defaultFilterModel";

type FilterContextType = {
  filterModel: FilterModel | null;
  setFilterModel: Dispatch<SetStateAction<FilterModel | null>>;
};

export const FilterContext = createContext<FilterContextType>({
  filterModel: defaultFilterModel, // أو null لو حابب تبدأ فاضي
  setFilterModel: () => {}
});

export function FilterProvider({ children }: { children: ReactNode }) {
  const [filterModel, setFilterModel] = useState<FilterModel | null>(defaultFilterModel);

  return (
    <FilterContext.Provider value={{ filterModel, setFilterModel }}>
      {children}
    </FilterContext.Provider>
  );
}
