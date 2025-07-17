"use client";

// Style module
import styles from "./main.module.css";

// Tools
import { useContext, useEffect, useState } from "react";
import { FilterContext } from "@/app/Components/Contexts/FilterContext";
import { Game } from "@/app/Components/models/game";

// Icons
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faGamepad,
  faDatabase,
  faList,
  faVcard,
  faAdd,
  faEdit,
  faTrash,
} from "@fortawesome/free-solid-svg-icons";

// Cards
import CardContener from "@/app/Components/Cards/card/cards";
import ListContener from "@/app/Components/Cards/list/lists";

// Contexts
import { ControlContext } from "@/app/Components/Contexts/ControlContext";

function Main() {
  const [Mod, setMod] = useState<string>("defualtCard");
  const [test, setTest] = useState("");
  const { filterModel } = useContext(FilterContext);
  const [Games, setGames] = useState<Game[]>([]);
  const { gameID } = useContext(ControlContext);
  const [isNotFound, setIsNotFound] = useState(false);

  useEffect(() => {
    console.log("Game ID:", gameID);
  }, [gameID]);

  useEffect(() => {
    console.log(test, gameID);
  }, [test]);

  useEffect(() => {
    console.log(Mod);
  }, [Mod]);

  useEffect(() => {
    setGames([]);
    if (filterModel) {
      console.log("انا card وده جالي من filter:", filterModel);

      fetch("https://localhost:7165/api/Filter/SetFilterData", {
        method: "POST",
        headers: {
          "Content-Type": "application/json", // 👈 مهم جداً
        },
        body: JSON.stringify(filterModel),
      })
        .then((res) => res.json())
        .then((data) => setGames(data))
        .catch((err) => console.error(`Error: ${err}`));
    } else {
      fetch("https://localhost:7165/api/Library/GetAllForDisplay")
        .then((res) => res.json())
        .then((data) => setGames(data))
        .catch((err) => console.error("❌ خطأ أثناء جلب البيانات:", err));
      console.log("تحديث جديد");
    }
    if (Games.length === 0) setIsNotFound(true);
    else setIsNotFound(false);
  }, [filterModel]);

  return (
    <div className={styles.Content}>
      <div className={styles.Header}>
        <div className={styles.AppLogo}>
          <FontAwesomeIcon className={styles.Logo} icon={faGamepad} />
          <div>
            <div>GameDex - للعلق صلاح</div>
            <ul>
              <li>
                <FontAwesomeIcon icon={faGamepad} /> <span>{Games.length}</span>
              </li>
              <li>
                <FontAwesomeIcon icon={faDatabase} /> <span>12 MB</span>
              </li>
            </ul>
          </div>
        </div>

        <div className={styles.Controls}>
          <button
            className={styles.btnCreate}
            onClick={() => setTest("Create")}
          >
            <FontAwesomeIcon icon={faAdd} />
          </button>
          <button
            className={styles.btnUpdate}
            onClick={() => setTest("Update")}
          >
            <FontAwesomeIcon icon={faEdit} />
          </button>
          <button
            className={styles.btnDelete}
            onClick={() => setTest("Delete")}
          >
            <FontAwesomeIcon icon={faTrash} />
          </button>
        </div>
      </div>
      <div className={styles.PageMossContainer}>
        <ul>
          <li>
            <input
              type="radio"
              name="option"
              checked={Mod === "defualtCard"}
              onChange={() => setMod("defualtCard")}
            />
            <span
              className={
                Mod === "defualtCard"
                  ? `${styles.radioMark} ${styles.active}`
                  : styles.radioMark
              }
            >
              <FontAwesomeIcon icon={faVcard} />
            </span>
          </li>
          <li>
            <input
              type="radio"
              name="option"
              checked={Mod === "listCard"}
              onChange={() => setMod("listCard")}
            />
            <span
              className={
                Mod === "listCard"
                  ? `${styles.radioMark} ${styles.active}`
                  : styles.radioMark
              }
            >
              <FontAwesomeIcon icon={faList} />
            </span>
          </li>
        </ul>
      </div>
      {Mod === "defualtCard" && <CardContener games={Games} />}
      {Mod === "listCard" && <ListContener games={Games} />}
    </div>
  );
}

export default Main;
