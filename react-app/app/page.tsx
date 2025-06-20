'use client';

import styles from './page.module.css';
import Library from './LibraryPage/page';


function MyApp() {
  return (
    <div className={styles.page}>
          <Library/>
    </div>
  );
}

export default MyApp;
