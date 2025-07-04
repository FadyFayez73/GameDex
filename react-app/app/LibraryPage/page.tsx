import Styles from "./page.module.css";
import Filter from "./Components/Filter/page";
import Main from "./Components/Main/page";

import { FilterProvider } from "../Components/FilterContext";

function Library() {
  return (
    <FilterProvider>
      <div className={Styles.Content}>
        <div className={Styles.Filter}>
          <Filter />
        </div>
        <main className={Styles.Main}>
          <Main />
        </main>
      </div>
    </FilterProvider>
  );
}

export default Library;
