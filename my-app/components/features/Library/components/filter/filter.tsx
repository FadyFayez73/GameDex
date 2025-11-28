"use client";

import { useContext, useEffect, useState } from "react";

// UI components
import { Label } from "@/components/ui/label";
import { Checkbox } from "@/components/ui/checkbox";
import { Slider } from "@/components/ui/slider";
import { Input } from "@/components/ui/input";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Button } from "@/components/ui/button";

// Context + Model
import { FilterContext } from "@/components/contexts/FilterContext";
import { useFilterModel } from "@/components/models/filterModel"; // ✅ hook اللي فيه fetchGenres

type Section = {
  key: string;
  title: string;
  items: string[];
};

function Filter() {
  const { filterModel: contextFilterModel, setFilterModel } = useContext(FilterContext);

  // 👇 بدل defaultFilterModel.. نستخدم hook فيه الـgenres من الـAPI
  const localFilterModel = useFilterModel();

  // Initialize context with full filterModel once genres are loaded
  useEffect(() => {
    if (localFilterModel.checkboxes.genres.length > 0 && !contextFilterModel) {
      // Only set if context is still null (first load)
      setFilterModel(localFilterModel);
    }
  }, [localFilterModel.checkboxes.genres.length, contextFilterModel, setFilterModel]); // Only when genres are loaded and context is null

  // استخراج الأقسام تلقائيًا - use localFilterModel to show genres in UI
  const checkboxSections: Section[] = Object.entries(
    localFilterModel.checkboxes
  ).map(([key, items]) => ({
    key,
    title: key.charAt(0).toUpperCase() + key.slice(1),
    items,
  }));

  const initialFilters = Object.fromEntries(
    checkboxSections.map((s) => [s.key, []])
  );
  const initialRange = localFilterModel.range;
  const initialSortBy = localFilterModel.sortBy;

  const [filters, setFilters] =
    useState<Record<string, string[]>>(initialFilters);
  const [rangeFilters, setRangeFilters] = useState(initialRange);
  const [tempRangeFilters, setTempRangeFilters] = useState(initialRange);
  const [sortBy, setSortBy] = useState(initialSortBy);

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

  useEffect(() => {
    const model = {
      checkboxes: filters,
      range: rangeFilters,
      sortBy,
    };
    setFilterModel(model);
  }, [filters, rangeFilters, sortBy, setFilterModel]);

  const handleClearAll = () => {
    setFilters(initialFilters);
    setRangeFilters(initialRange);
    setSortBy(initialSortBy);
    setTempRangeFilters(initialRange);
  };

  return (
    <div className="w-full min-w-[250px] h-full flex flex-col items-center overflow-y-auto scrollbar-custom">
      {/* Search + Sort */}
      <div className="w-full p-2">
        <div className="w-full felx flex-row gap-1 px-6 pt-2">
          <h4 className="">Game Filter</h4>
        </div>
        <Input type="search" className="w-full mt-2" />
        <Select onValueChange={(value) => setSortBy(value)}>
          <SelectTrigger className="w-full mt-2">
            <SelectValue placeholder="Name" />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="name">Name</SelectItem>
            <SelectItem value="priceLowerToHigher">
              Price (Lower to Higher)
            </SelectItem>
            <SelectItem value="priceHigherToLower">
              Price (Higher to Lower)
            </SelectItem>
            <SelectItem value="sizeLowerToHigher">
              Size (Lower To Higher)
            </SelectItem>
            <SelectItem value="sizeHigherToLower">
              Size (Higher To Lower)
            </SelectItem>
            <SelectItem value="release">Release Date</SelectItem>
          </SelectContent>
        </Select>
      </div>

      {/* Ranges */}
      <div className="flex flex-col flex-shrink-1 w-full h-full p-2 overflow-y-auto scrollbar-custom">
        <Label className="w-full text-start text-xs mb-1 mt-2 text-gray-600">
          Ranges
        </Label>

        {/* Price slider */}
        <div className="w-full flex flex-col border-l-2 pl-2 gap-1">
          <div className="flex flex-row gap-2 w-full items-center justify-start">
            <Label className="text-xs text-gray-500">Price</Label>
            <Slider
              min={0}
              max={100}
              step={1}
              defaultValue={[0, 100]}
              value={[tempRangeFilters.price.min, tempRangeFilters.price.max]}
              onValueChange={(value) => {
                setTempRangeFilters((prev) => ({
                  ...prev,
                  price: { min: value[0], max: value[1] },
                }));
              }}
              onValueCommit={(value) =>
                setRangeFilters((prev) => ({
                  ...prev,
                  price: { min: value[0], max: value[1] },
                }))
              }
            />
            <Label className="text-xs text-gray-400">{`${tempRangeFilters.price.min} - ${tempRangeFilters.price.max}`}</Label>
          </div>

          {/* Size slider */}
          <div className="flex flex-row gap-2 w-full items-center justify-start">
            <Label className="text-xs text-gray-500 w-[47px]">Size</Label>
            <Slider
              min={0}
              max={100}
              step={1}
              defaultValue={[0, 100]}
              value={[tempRangeFilters.size.min, tempRangeFilters.size.max]}
              onValueChange={(value) =>
                setTempRangeFilters((prev) => ({
                  ...prev,
                  size: { min: value[0], max: value[1] },
                }))
              }
              onValueCommit={(value) =>
                setRangeFilters((prev) => ({
                  ...prev,
                  size: { min: value[0], max: value[1] },
                }))
              }
            />
            <Label className="text-xs text-gray-400">{`${tempRangeFilters.size.min} - ${tempRangeFilters.size.max}`}</Label>
          </div>
        </div>

        {/* Checkbox Sections */}
        {checkboxSections.map((section) => (
          <div key={section.title}>
            <Label className="w-full text-start text-xs mb-1 mt-2 text-gray-600">
              {section.title}
            </Label>

            <div className="w-full flex flex-col border-l-2 pl-2 gap-1">
              {section.items.map((item) => (
                <div
                  key={item}
                  className="flex flex-row gap-2 w-full items-center justify-start"
                >
                  <Checkbox
                    checked={!!filters[section.key]?.includes(item)}
                    onCheckedChange={() => toggleValue(section.key, item)}
                  />
                  <Label>{item}</Label>
                </div>
              ))}
            </div>
          </div>
        ))}
      </div>

      {/* Buttons */}
      <div className="w-full flex flex-row gap-1 p-2 pt-4 ">
        <Button onClick={handleClearAll} className="w-full">
          Clear
        </Button>
      </div>
    </div>
  );
}

export default Filter;
