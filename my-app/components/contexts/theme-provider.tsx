'use client';

import { createContext, useContext, useState, useEffect } from 'react';

export type Themes = 'light' | 'dark' | 'solarized';

interface ThemeContextType {
  theme: Themes;
  setTheme: (theme: Themes) => void;
}

const ThemeContext = createContext<ThemeContextType | undefined>(undefined);

export const ThemeProvider = ({ children }: { children: React.ReactNode }) => {
  const [theme, setTheme] = useState<Themes>('light');

  useEffect(() => {
    document.documentElement.classList.remove('light', 'dark', 'solarized');
    document.documentElement.classList.add(theme);
  }, [theme]);

  return (
    <ThemeContext.Provider value={{ theme, setTheme }}>
      {children}
    </ThemeContext.Provider>
  );
};

export const useTheme = () => {
  const context = useContext(ThemeContext);
  if (!context) throw new Error('useTheme must be used within ThemeProvider');
  return context;
};
