"use client";

import {
  createContext,
  useState,
  ReactNode,
  Dispatch,
  SetStateAction,
} from "react";
import { FilterModel, defaultFilterModel } from "../models/filterModel";

type FilterContextType = {
  filterModel: FilterModel | null;
  setFilterModel: Dispatch<SetStateAction<FilterModel | null>>;
};

export const FilterContext = createContext<FilterContextType>({
  filterModel: null, // Start with null to prevent premature filter requests
  setFilterModel: () => { },
});

export function FilterProvider({ children }: { children: ReactNode }) {
  const [filterModel, setFilterModel] = useState<FilterModel | null>(
    null // Start with null until genres are loaded
  );

  return (
    <FilterContext.Provider value={{ filterModel, setFilterModel }}>
      {children}
    </FilterContext.Provider>
  );
}
