"use client";
import { useContext, useEffect, useRef, useState } from "react";
import styles from "./filter.module.css";
import { FilterContext } from "@/app/Components/Contexts/FilterContext";
import { defaultFilterModel } from "@/app/Components/models/defaultFilterModel";

import RangeSlider from "react-range-slider-input";
import "react-range-slider-input/dist/style.css";
import "./custom-slider.css"; // ملف CSS مخصصك


type Section = {
  key: string;
  title: string;
  items: string[];
};

export default function FilterList() {
  const { setFilterModel } = useContext(FilterContext);
  const [shouldSubmitAfterClear, setShouldSubmitAfterClear] = useState(false);

  const [rangePriceValue, setRangePriceValue] = useState([0, 0]);
  const [rangeSizeValue, setRangeSizeValue] = useState([0, 0]);

  // استخراج الأقسام تلقائيًا من default model
  const checkboxSections: Section[] = Object.entries(
    defaultFilterModel.checkboxes
  ).map(([key, items]) => ({
    key,
    title: key.charAt(0).toUpperCase() + key.slice(1),
    items,
  }));

  const initialFilters = Object.fromEntries(
    checkboxSections.map((s) => [s.key, []])
  );
  const initialRange = defaultFilterModel.range;
  const initialSortBy = defaultFilterModel.sortBy;

  const [collapsed, setCollapsed] = useState<Record<string, boolean>>(() =>
    Object.fromEntries(checkboxSections.map((s) => [s.key, true]))
  );

  const [filters, setFilters] =
    useState<Record<string, string[]>>(initialFilters);
  const [rangeFilters, setRangeFilters] = useState(initialRange);
  const [sortBy, setSortBy] = useState(initialSortBy);

  const contentRefs = useRef<Record<string, HTMLDivElement | null>>({});

  const toggleCollapse = (key: string) => {
    setCollapsed((prev) => ({ ...prev, [key]: !prev[key] }));
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

  // const handleRangeChange = (
  //   type: "price" | "size",
  //   field: "min" | "max",
  //   value: string
  // ) => {
  //   setRangeFilters((prev) => ({
  //     ...prev,
  //     [type]: { ...prev[type], [field]: Number(value) },
  //   }));
  // };

  useEffect(() => {
    if (shouldSubmitAfterClear) {
      handleSubmit();
      setShouldSubmitAfterClear(false); // reset
    }
  }, [filters, rangeFilters, sortBy, shouldSubmitAfterClear]);

  const handleSubmit = () => {
    const model = {
      checkboxes: filters,
      range: rangeFilters,
      sortBy: sortBy,
    };
    setFilterModel(model);
    console.log("from handleSubmit", model);
  };

  const handleClearAll = () => {
    setFilters(initialFilters);
    setRangeFilters(initialRange);
    setSortBy(initialSortBy);
    setShouldSubmitAfterClear(true); // اطلب تنفيذ submit بعد ما الحالة تتحدث
  };

  return (
    <div className={styles.container}>
      <div className={styles.FilterComponents}>
        {/* Sort */}
        <div className={styles.sortSection}>
          <label>Sort By:</label>
          <select
            value={sortBy}
            onChange={(e) => setSortBy(e.target.value)}
            className={styles.select}
          >
            <option value="name">Name</option>
            <option value="priceLowerToHigher">Price (Lower to Higher)</option>
            <option value="priceHigherToLower">Price (Higher to Lower)</option>
            <option value="sizeLowerToHigher">Size (Lower To Higher)</option>
            <option value="sizeHigherToLower">Size (Higher To Lower)</option>
            <option value="release">Release Date</option>
          </select>
        </div>

        {/* Range Filters */}

        <div className={styles.rangeSection}>
          <h5>
            Price Range <span>({rangePriceValue.join("$ - ")}$)</span>
          </h5>
          <RangeSlider
            className="my-slider"
            min={0}
            max={200}
            defaultValue={[0, 200]}
            onInput={(value) => {
              console.log("Selected range:", value);
              setRangePriceValue([value[0], value[1]]);
            }}
          />
          <h5>
            Size Range <span>({rangeSizeValue.join("GB - ")}GB)</span>
          </h5>
          <RangeSlider
            className="my-slider"
            min={0}
            max={200}
            defaultValue={[0, 200]}
            onInput={(value) => {
              console.log("Selected range:", value);
              setRangeSizeValue([value[0], value[1]]);
            }}
          />
        </div>

        {/* Checkbox Sections */}
        {checkboxSections.map((section) => {
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
                    : `${
                        contentRefs.current[section.key]?.scrollHeight || 0
                      }px`,
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
      </div>

      {/* Buttons */}
      <div className={styles.buttonGroup}>
        <button onClick={handleSubmit} className={styles.submit}>
          Apply Filters
        </button>
        <button onClick={handleClearAll} className={styles.clear}>
          Clear
        </button>
      </div>
    </div>
  );
}
