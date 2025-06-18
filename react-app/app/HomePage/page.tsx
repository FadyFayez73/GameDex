'use client';

import { useProductsState } from '@/store/useFilterStore';
import Styles from './page.module.css';
import { useState } from 'react';
import GetTopTenGames from './Components/TopTenGames/page'

function Home() {
  const [SideList, setSideList] = useState(false)
  return (
    <>
    <div className={Styles.Content}>
      <GetTopTenGames />
      <GetTopTenGames />
    </div>
    </>
  );
}

export default Home;