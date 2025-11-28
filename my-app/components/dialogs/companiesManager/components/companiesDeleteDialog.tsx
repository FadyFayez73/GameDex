import { apiUrl } from "@/app/api-config";
import { Company } from "@/components/models/company";
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";

type Props = {
  onDeleted?: (deletedCompany: boolean) => void; // 👈 callback بيرجع للـDialog الأب
  company: Company; // 👈 callback بيرجع للـDialog الأب
};

function CompaniesDeleteDialog({ onDeleted, company }: Props) {
  const [open, setOpen] = useState(false); // 👈 تحكم في فتح/قفل المودال

  const handleSubmit = async () => {
    console.log("📌 handleSubmit fired!");

    const res = await fetch(`${apiUrl}/Companies/${company.companyId}`, {
      method: "DELETE",
    });

    if (res.ok) {
      const state = await res.status;
      // نرجعه للأب
      if (onDeleted) onDeleted(state === 204 ? true : false);

      // قفل المودال
      setOpen(false);
    } else {
      const err = await res.text();
      console.error("Error deleting company: " + err);
    }
  };

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <button className="cursor-pointer">
          <FontAwesomeIcon icon={faTrash} />
        </button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>Delete Company</DialogTitle>
          <DialogDescription>
            Fill in the details below to create a new company.
          </DialogDescription>
        </DialogHeader>
        <div className="text-center mb-4">
          Are you sure you want to delete the company &quot;{company.name}&quot;
        </div>
        <DialogFooter>
          <DialogClose asChild>
            <Button variant="outline">Cancel</Button>
          </DialogClose>
          <Button onClick={() => handleSubmit()}>Yes</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}

export default CompaniesDeleteDialog;
