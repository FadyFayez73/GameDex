// FilterContext.tsx
import { createContext, useState } from "react";

export const FilterContext = createContext({
  filterModel: null,
  setFilterModel: (_: any) => {}
});

export function FilterProvider({ children }: { children: React.ReactNode }) {
  const [filterModel, setFilterModel] = useState(null);

  return (
    <FilterContext.Provider value={{ filterModel, setFilterModel }}>
      {children}
    </FilterContext.Provider>
  );
}
