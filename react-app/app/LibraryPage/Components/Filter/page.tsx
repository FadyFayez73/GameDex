'use client';
import { useRef, useState, useEffect } from "react";
import clsx from "clsx";
import styles from "./page.module.css";

type Section = {
  key: string;
  title: string;
  items: string[];
};

const sections: Section[] = [
  {
    key: "genres",
    title: "Genres",
    items: ["RPG", "Open World", "Story Rich", "Atmospheric"],
  },
  {
    key: "platforms",
    title: "Platforms",
    items: ["PC", "PlayStation", "Xbox", "Switch"],
  },
  {
    key: "tags",
    title: "Tags",
    items: ["Multiplayer", "Single Player", "Controller Support"],
  },
];

export default function FilterList() {
  const [collapsed, setCollapsed] = useState<Record<string, boolean>>(() =>
    Object.fromEntries(sections.map((s) => [s.key, true]))
  );

  const [filters, setFilters] = useState<Record<string, string[]>>(() =>
    Object.fromEntries(sections.map((s) => [s.key, []]))
  );

  const [rangeFilters, setRangeFilters] = useState({
    price: { min: 0, max: 0 },
    size: { min: 0, max: 0 },
  });

  const [sortBy, setSortBy] = useState("name");

  const contentRefs = useRef<Record<string, HTMLDivElement | null>>({});

  const toggleCollapse = (key: string) => {
    setCollapsed((prev) => ({
      ...prev,
      [key]: !prev[key],
    }));
  };

  const toggleValue = (sectionKey: string, value: string) => {
    setFilters((prev) => {
      const current = prev[sectionKey] || [];
      return {
        ...prev,
        [sectionKey]: current.includes(value)
          ? current.filter((v) => v !== value)
          : [...current, value],
      };
    });
  };

  const handleRangeChange = (
    type: "price" | "size",
    field: "min" | "max",
    value: string
  ) => {
    setRangeFilters((prev) => ({
      ...prev,
      [type]: { ...prev[type], [field]: Number(value) },
    }));
  };

  const handleSubmit = () => {
    const model = {
      checkboxes: filters,
      range: rangeFilters,
      sortBy: sortBy,
    };
    console.log("Filter model:", model);
    // await fetch("/api/search", { method: "POST", body: JSON.stringify(model) })
  };

  return (
    <div className={styles.container}>
      {/* Sorting */}
      <div className={styles.sortSection}>
        <label>Sort By:</label>
        <select
          value={sortBy}
          onChange={(e) => setSortBy(e.target.value)}
          className={styles.select}
        >
          <option value="name">Name</option>
          <option value="size">Size</option>
          <option value="release">Release Date</option>
        </select>
      </div>

      {/* Range Filters */}
      <div className={styles.rangeSection}>
        <h4>Price Range</h4>
        <div className={styles.rangeRow}>
          <input
            type="number"
            value={rangeFilters.price.min}
            onChange={(e) =>
              handleRangeChange("price", "min", e.target.value)
            }
            placeholder="Min"
          />
          <span>–</span>
          <input
            type="number"
            value={rangeFilters.price.max}
            onChange={(e) =>
              handleRangeChange("price", "max", e.target.value)
            }
            placeholder="Max"
          />
        </div>
      </div>

      {/* Sections with Collapse + Checkboxes */}
      {sections.map((section) => {
        const isCollapsed = collapsed[section.key];
        const ref = (el: HTMLDivElement | null) => {
          contentRefs.current[section.key] = el;
        };

        return (
          <div key={section.key} className={styles.collection}>
            <h4 className={styles.title}>{section.title}</h4>

            <div
              ref={ref}
              className={styles.items}
              style={{
                maxHeight: isCollapsed
                  ? "0px"
                  : `${contentRefs.current[section.key]?.scrollHeight || 0}px`,
                overflow: "hidden",
                transition: "max-height 0.4s ease",
              }}
            >
              {section.items.map((item) => (
                <label key={item} className={styles.item}>
                  <input
                    type="checkbox"
                    checked={filters[section.key]?.includes(item)}
                    onChange={() => toggleValue(section.key, item)}
                  />
                  {item}
                </label>
              ))}
            </div>

            <button
              className={styles.toggle}
              onClick={() => toggleCollapse(section.key)}
            >
              {isCollapsed ? "View All" : "Collapse"}
            </button>
          </div>
        );
      })}

      {/* Submit Button */}
      <button onClick={handleSubmit} className={styles.submit}>
        Apply Filters
      </button>
    </div>
  );
}
