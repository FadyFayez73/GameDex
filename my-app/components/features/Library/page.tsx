"use client";

import { useState } from "react";

import Filter from "./components/filter/filter";
import Main from "./components/main/main";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSliders } from "@fortawesome/free-solid-svg-icons";
import { FilterProvider } from "@/components/contexts/FilterContext";
import { ControlProvider } from "@/components/contexts/ControlContext";
import { cn } from "@/lib/utils";

function LibraryPage() {
  const [isCollapsed, setIsCollapsed] = useState(false);

  return (
    <FilterProvider>
      <div className="w-full h-full flex flex-row relative">
        <button
          className="fixed top-[17px] left-2 z-50 cursor-pointer text-foreground hover:text-primary transition-colors"
          onClick={() => setIsCollapsed(!isCollapsed)}
          aria-label="Toggle Sidebar"
        >
          <FontAwesomeIcon icon={faSliders} />
        </button>
        <div
          className={cn(
            "h-full border-r overflow-hidden transition-all duration-500 ease-in-out bg-background",
            isCollapsed ? "w-0 min-w-0 opacity-0" : "w-[250px] min-w-[250px] opacity-100"
          )}
        >
          <div className="w-[250px] h-full">
            <Filter />
          </div>
        </div>
        <ControlProvider>
          <div className="w-full h-full overflow-hidden">
            <Main isCollapsed={isCollapsed} />
          </div>
        </ControlProvider>
      </div>
    </FilterProvider>
  );
}

export default LibraryPage;
