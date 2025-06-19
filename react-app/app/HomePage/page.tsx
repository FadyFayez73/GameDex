'use client';

import { useProductsState } from '@/store/useFilterStore';
import Styles from './page.module.css';
import { useState } from 'react';
import GetTopTenGames from './Components/TopTenGames/page'
import LastGames from './Components/TopGamesAdded/page'

function Home() {
  const [SideList, setSideList] = useState(false)
  return (
    <>
    <div className={Styles.Content}>
      <GetTopTenGames />
      <LastGames />
    </div>
    </>
  );
}

export default Home;