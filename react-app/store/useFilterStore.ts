// src/store/useProductsState.ts
import { create } from 'zustand';

interface ProductsPageState {
  filter: string;
  page: number;
  sortBy: string;
  inputText: string;

  setFilter: (value: string) => void;
  setPage: (value: number) => void;
  setSortBy: (value: string) => void;
  setInputText: (value: string) => void;
}

export const useProductsState = create<ProductsPageState>((set) => ({
  filter: '',
  page: 1,
  sortBy: 'default',
  inputText: '',

  setFilter: (value) => set({ filter: value }),
  setPage: (value) => set({ page: value }),
  setSortBy: (value) => set({ sortBy: value }),
  setInputText: (value) => set({ inputText: value }),
}));
