"use client";

import Styles from "./page.module.css";
import Filter from "./Components/Filter/filter";
import Main from "./Components/Main/main";

import { FilterProvider } from "../Components/Contexts/FilterContext";
import { ControlProvider } from "../Components/Contexts/ControlContext";
import { useEffect, useState } from "react";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBars } from "@fortawesome/free-solid-svg-icons";

function Library() {
  const [isCollapsed, setIsCollapsed] = useState(false);

  useEffect(() => {
    console.log("نجح", isCollapsed);
  }, [isCollapsed]);

  return (
    <FilterProvider>
      <div className={Styles.Content}>
        <div
          className={Styles.Filter}
          style={{
            marginLeft: isCollapsed ? "0" : "-270px",
            transition: "0.3s",
          }}
        >
          <button
            className={Styles.CollapseButton}
            onClick={() => setIsCollapsed(!isCollapsed)}
          >
            <FontAwesomeIcon icon={faBars} />
          </button>
          <Filter />
        </div>
        <ControlProvider>
          <main className={Styles.Main} style={{ width: "100%" }}>
            <Main />
          </main>
        </ControlProvider>
      </div>
    </FilterProvider>
  );
}

export default Library;
