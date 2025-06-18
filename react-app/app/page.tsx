'use client';

import { useState } from 'react';
import styles from './page.module.css';
import Home from './HomePage/page';
import Library from './LibraryPage/page';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHome, faGamepad } from "@fortawesome/free-solid-svg-icons";

function SidebarActive(PageName: string){

}

function MyApp() {
  const [currentPage, setCurrentPage] = useState('home')

  return (
    <div className={styles.page}>

      <div className={styles.aside}>
        <nav>
          <ul>
            <li>
              <a onClick={() => setCurrentPage('home')}
                className={currentPage === 'home' ? styles.active : ""}>
                <FontAwesomeIcon icon={faHome} />
              </a>
            </li>
            <li>
              <a  onClick={() => setCurrentPage('library')}
                className={currentPage === 'library' ? styles.active : ""}>
                <FontAwesomeIcon icon={faGamepad} />
              </a>
            </li>
          </ul>
        </nav>
      </div>

      <main className={styles.main}>
        
        <div className={styles.Content} style={{ display: currentPage === 'home' ? 'block' : 'none' }}>
          <Home/>
        </div>

        <div className={styles.Content} style={{ display: currentPage === 'library' ? 'block' : 'none' }}>
          <Library/>
        </div>
        
      </main>

    </div>
  );
}

export default MyApp;
