import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
// import { Input } from "@/components/ui/input";
// import { Label } from "@/components/ui/label";

import {
  faIcons,
} from "@fortawesome/free-solid-svg-icons";


import { Dispatch, SetStateAction, useEffect, useState } from "react";

// Models
import { Company } from "@/components/models/company";

// Config
import { apiUrl } from "@/app/api-config";
import CompaniesCreateDialog from "./components/companiesCreateDialog";
import CompaniesDeleteDialog from "./components/companiesDeleteDialog";
import CompaniesUpdatingDialog from "./components/companiesUpdateDialog";

const GetCompanies = async (
  setCompanies: Dispatch<SetStateAction<Company[] | null>>
) => {
  fetch(`${apiUrl}/companies/`)
    .then((res) => res.json())
    .then((data) => setCompanies(data))
    .catch((err) => console.error(err));
};

export function CompaniesManagerDialog() {
  const [companies, setCompanies] = useState<Company[] | null>(null);

  useEffect(() => {
    GetCompanies(setCompanies);
  }, []);

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button className="h-6 w-6 px-0 py-0 text-xs font-bold leading-none bg-transparent text-xs cursor-pointer text-gray-900  dark:text-gray-100 hover:bg-transparent hover:text-gray-700 hover:dark:text-gray-700">
          <FontAwesomeIcon icon={faIcons} />
        </Button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[70%] sm:min-h-[90vh] sm:max-h-[90vh] lg:max-w-[50%] flex flex-col overflow-hidden">
        <DialogHeader>
          <DialogTitle>Companies Manager</DialogTitle>
          <DialogDescription>
            Make changes to your profile here. Click save when youre done.{" "}
            {companies ? `Companies: ${companies?.length}` : ""}
          </DialogDescription>
        </DialogHeader>
        {/* Creeat Button */}
        <div className="flex justify-end mb-4">
          <CompaniesCreateDialog
            onCreated={(value) => {
              if (value) GetCompanies(setCompanies);
            }}
          />
        </div>
        {/* Content */}
        <div className="grid grid-cols-2 gap-4 mb-4 pr-2 overflow-y-auto scrollbar-custom">
          {companies?.map((company) => (
            <div
              key={company.companyId}
              className="flex flex-col items-center gap-1"
            >
              <div className="flex flex-col w-full">
                <span className="font-bold text-sm">{company.name}</span>
                <span className="text-sm text-gray-500 text-wrap dark:text-gray-400">
                  {company.description}
                </span>
              </div>
              <div className="w-full flex flex-row justify-end items-center text-sm">
                <CompaniesUpdatingDialog
                  company={company}
                  onUpdated={(value) => {
                    if (value)
                      GetCompanies(setCompanies);
                  }}
                />

                <CompaniesDeleteDialog
                  company={company}
                  onDeleted={(value) => {
                    if (value)
                      GetCompanies(setCompanies);
                  }}
                />
              </div>
            </div>
          ))}
        </div>
      </DialogContent>
    </Dialog>
  );
}
