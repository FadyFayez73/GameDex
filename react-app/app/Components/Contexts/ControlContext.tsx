'use client';

import { createContext, useState, ReactNode, Dispatch, SetStateAction } from 'react';
import { v4 as uuidv4 } from 'uuid';

type ControlContextType = {
  gameID: string;
  setGameID: Dispatch<SetStateAction<string>>;
};

const defaultGameID = uuidv4();

export const ControlContext = createContext<ControlContextType>({
  gameID: defaultGameID,
  setGameID: () => {}, 
});

type ControlProviderProps = {
  children: ReactNode;
};

export function ControlProvider({ children }: ControlProviderProps) {
  const [gameID, setGameID] = useState<string>(defaultGameID); 

  return (
    <ControlContext.Provider value={{ gameID, setGameID }}>
      {children}
    </ControlContext.Provider>
  );
}
