"use client";

// Style module
import styles from "./page.module.css";

// Tools
import { useContext, useEffect, useState } from "react";

// Icons
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faGamepad,
  faDatabase,
  faList,
  faVcard,
} from "@fortawesome/free-solid-svg-icons";

import CardContener from "@/app/Components/Cards/card/page";
import ListContener from "@/app/Components/Cards/list/page";

function Main() {
  const [Mod, setMod] = useState<string>("defualtCard");
  const [length, setLength] = useState<number>();

  const [test, setTest] = useState("create");

  useEffect(() => {
    console.log(test);
  }, [test]);

  useEffect(() => {
    console.log(Mod);
  }, [Mod]);

  const handleDataFromCard = (length: number) => {
    setLength(length);
  };



  return (
    <div className={styles.Content}>
      <div className={styles.Header}>
        <div className={styles.AppLogo}>
          <FontAwesomeIcon className={styles.Logo} icon={faGamepad} />
          <div>
            <div>GameDex - للعلق صلاح</div>
            <ul>
              <li>
                <FontAwesomeIcon icon={faGamepad} /> <span>{length}</span>
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
            Create
          </button>
          <button
            className={styles.btnUpdate}
            onClick={() => setTest("Update")}
          >
            Update
          </button>
          <button
            className={styles.btnDelete}
            onClick={() => setTest("Delete")}
          >
            Delete
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
      {Mod === "defualtCard" && <CardContener onLength={handleDataFromCard} />}
      {Mod === "listCard" && <ListContener />}
    </div>
  );
}

export default Main;
