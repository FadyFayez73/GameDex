'use client';

import { createContext, useState, ReactNode, Dispatch, SetStateAction } from "react";

// 1. تعريف نوع البيانات الخاصة بالسياق
type ControlContextType = {
  gameID: number;
  setGameID: Dispatch<SetStateAction<number>>;
};

// 2. إنشاء السياق بنوع مضبوط
export const ControlContext = createContext<ControlContextType>({
  gameID: 0,
  setGameID: () => {}, // dummy function (safe fallback)
});

// 3. تعريف نوع props الخاصة بالـ Provider
type ControlProviderProps = {
  children: ReactNode;
};

// 4. الكومبوننت نفسها
export function ControlProvider({ children }: ControlProviderProps) {
  const [gameID, setGameID] = useState<number>(0);

  return (
    <ControlContext.Provider value={{ gameID, setGameID }}>
      {children}
    </ControlContext.Provider>
  );
}
