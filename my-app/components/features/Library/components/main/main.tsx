import { useContext, useEffect, useState } from "react";

// Contexts
import { FilterContext } from "@/components/contexts/FilterContext";
import { ControlContext } from "@/components/contexts/ControlContext";

// Icons
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faGamepad,
  faList,
  faVcard,
  faTrash,
  faIcons,
} from "@fortawesome/free-solid-svg-icons";

// Components
import { Button } from "@/components/ui/button";

// Dialogs
import { CreateDialog } from "@/components/dialogs/CreateDialog";
import { UpdateDialog } from "@/components/dialogs/UpdateDialog";
import { GenresManagerDialog } from "@/components/dialogs/genresManager/GenresManagerDialog";
import { SettingsDialog } from "@/components/dialogs/SettingsDialog";

// Pages
import { GameForDisplay } from "@/components/models/GameFoDisplay";
import CardContener from "@/components/view/card/card-collection";
import ListContener from "@/components/view/list/list-collection";
import IconContener from "@/components/view/smallIcons/icon-collection";

import GradientText from "@/components/reactbits/GradientText/GradientText";
// Config
import { apiUrl } from "@/app/api-config";
import { CompaniesManagerDialog } from "@/components/dialogs/companiesManager/CompaniesManagerDialog";

type prop = {
  isCollapsed: boolean;
};

function Main({ isCollapsed }: prop) {
  const [Mod, setMod] = useState<string>("defualtCard");
  const { filterModel } = useContext(FilterContext);
  const [games, setGames] = useState<GameForDisplay[]>([]);
  const { gameID } = useContext(ControlContext);

  const [isNotFound, setIsNotFound] = useState(false);

  useEffect(() => {
    const fetchGames = async () => {
      if (!filterModel) {
        console.log('⏳ Waiting for filterModel to be initialized...');
        return;
      }

      console.log('🎮 Fetching games with filter:', filterModel);

      try {
        const response = await fetch(`${apiUrl}/Filter`, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(filterModel),
        });

        if (response.ok) {
          const data = await response.json();
          setGames(data);
          setIsNotFound(data.length === 0);
        } else {
          // Log detailed error for debugging
          const errorText = await response.text();
          console.error(`Failed to fetch games: ${response.status} ${response.statusText}`);
          console.error('Request body:', JSON.stringify(filterModel, null, 2));
          console.error('Response:', errorText);
          setGames([]);
          setIsNotFound(true);
        }
      } catch (error) {
        console.error('Network error while fetching games:', error);
        setGames([]);
        setIsNotFound(true);
      }
    };

    fetchGames();
  }, [filterModel]);



  return (
    <div className="w-full h-full flex flex-col gap-2 items-center p-2 overflow-hidden">
      {/* Main Header */}
      <div className="w-full border-b-1 flex flex-row justify-between p-2">
        <div className="flex flex-row gap-2 items-center">
          <div className={`${isCollapsed ? "ml-4" : ""} duration-300`}>
            <GradientText
              colors={["#40ffaa", "#4079ff", "#40ffaa", "#4079ff", "#40ffaa"]}
              animationSpeed={20}
              showBorder={false}
              className="text-bold"
            >
              GameDex
            </GradientText>
          </div>
          <div className="flex flex-row gap-1">
            <span className="text-xs text-gray-400 flex flex-row items-center gap-1">
              <FontAwesomeIcon icon={faGamepad} />
              {games.length}
            </span>
          </div>
        </div>
        <div className="flex flex-row items-center gap-1 w-[fit-content] h-[fit-content]">
          <SettingsDialog />
          <div className="p-0 border-1 h-[20px] mx-2"></div>
          <GenresManagerDialog />
          <CompaniesManagerDialog />
          <div className="p-0 border-1 h-[20px] mx-2"></div>
          <CreateDialog />
          <UpdateDialog gameId={gameID} />
          <Button className="h-6 w-6 px-0 py-0 text-xs font-bold leading-none bg-transparent text-xs cursor-pointer text-gray-900 dark:text-gray-100 hover:bg-transparent hover:text-gray-700 hover:dark:text-gray-700">
            <FontAwesomeIcon icon={faTrash} />
          </Button>
        </div>
      </div>

      {/* View Control */}
      <div className="w-full flex flex-row gap-1 items-center justify-end px-2">
        <ul className="flex space-x-1">
          <li>
            <label className="cursor-pointer flex items-center gap-2">
              <input
                type="radio"
                name="option"
                value="defualtCard"
                checked={Mod === "defualtCard"}
                onChange={() => setMod("defualtCard")}
                className="peer hidden"
              />
              <span className="flex items-center justify-center w-5 h-5 text-gray-400 transition-colors duration-300 peer-checked:text-black peer-checked:dark:text-blue-500">
                <FontAwesomeIcon icon={faVcard} />
              </span>
            </label>
          </li>
          <li>
            <label className="cursor-pointer flex items-center gap-2">
              <input
                type="radio"
                name="option"
                value="listCard"
                checked={Mod === "listCard"}
                onChange={() => setMod("listCard")}
                className="peer hidden"
              />
              <span className="flex items-center justify-center w-5 h-5 text-gray-400 transition-colors duration-300 peer-checked:text-black peer-checked:dark:text-blue-500">
                <FontAwesomeIcon icon={faList} />
              </span>
            </label>
          </li>
          <li>
            <label className="cursor-pointer flex items-center gap-2">
              <input
                type="radio"
                name="option"
                value="smalliIcons"
                checked={Mod === "smalliIcons"}
                onChange={() => setMod("smalliIcons")}
                className="peer hidden"
              />
              <span className="flex items-center justify-center w-5 h-5 text-gray-400 transition-colors duration-300 peer-checked:text-black peer-checked:dark:text-blue-500">
                <FontAwesomeIcon icon={faIcons} />
              </span>
            </label>
          </li>
        </ul>
      </div>

      {/* Content */}
      {Mod === "defualtCard" && (
        <CardContener games={games} isNotFound={isNotFound} />
      )}
      {Mod === "listCard" && (
        <ListContener games={games} isNotFound={isNotFound} />
      )}
      {Mod === "smalliIcons" && (
        <IconContener games={games} isNotFound={isNotFound} />
      )}
    </div>
  );
}

export default Main;
