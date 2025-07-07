import Styles from "./page.module.css";
import Filter from "./Components/Filter/filter";
import Main from "./Components/Main/main";

import { FilterProvider } from "../Components/Contexts/FilterContext";
import { ControlProvider } from "@/app/Components/Contexts/ControlContext";

function Library() {
  return (
    <FilterProvider>
      <div className={Styles.Content}>
        <div className={Styles.Filter}>
          <Filter />
        </div>
        <ControlProvider>
          <main className={Styles.Main}>
            <Main />
          </main>
        </ControlProvider>
      </div>
    </FilterProvider>
  );
}

export default Library;
