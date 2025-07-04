"use client";

import styles from "./page.module.css";
import Card from "./Components/Card-Default";
import { FilterContext } from "@/app/Components/FilterContext";

import { Game } from "../../models/game";
import { useContext, useEffect, useState } from "react";

function Contener({ onLength = (length: number) => {} }) {
  const [Games, setGames] = useState<Game[]>([]);
  const { filterModel } = useContext(FilterContext);

  useEffect(() => {
    fetch("https://10.0.0.10:7165/api/Library/GetAllForDisplay")
      .then((res) => res.json())
      .then((data) => setGames(data))
      .catch((err) => console.error("❌ خطأ أثناء جلب البيانات:", err));
  }, [filterModel === null]);

  const setDataToMain = () => {
    onLength(Games.length);
  };

  useEffect(() => {
    setDataToMain();
  }, [Games]);

  useEffect(() => {
    if (filterModel) {
      console.log("انا card وده جالي من filter:", filterModel);
      // تعمل API request تانية هنا أو تعرض بيانات معينة

      fetch("https://10.0.0.10:7165/api/Library/Filter", {
        method: "POST",
        headers: {
          "Content-Type": "application/json", // 👈 مهم جداً
        },
        body: JSON.stringify(filterModel),
      })
        .then((res) => res.json())
        .then((data) => setGames(data))
        .catch((err) => console.error(`Error: ${err}`));
    }
  }, [filterModel]);

  return (
    <div className={styles.Content}>
      {Games.length === 0 ? (
        <p>Loading...</p>
      ) : (
        Games.map((game) => <Card key={game.gameID} game={game} />)
      )}
    </div>
  );
}

export default Contener;
