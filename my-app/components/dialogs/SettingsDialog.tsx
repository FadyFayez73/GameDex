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
import {
  Table,
  TableHeader,
  TableBody,
  TableRow,
  TableHead,
  TableCell,
} from "@/components/ui/table";

import { faGear } from "@fortawesome/free-solid-svg-icons";

import { useTheme, Themes } from "@/components/contexts/theme-provider";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

// Config
// import { apiUrl } from "@/app/api-config";

export function SettingsDialog() {
  const { theme, setTheme } = useTheme();

  return (
    <Dialog>
      <form>
        <DialogTrigger asChild>
          <Button className="h-6 w-6 px-0 py-0 text-xs font-bold leading-none bg-transparent text-xs cursor-pointer text-gray-900 dark:text-gray-100 hover:bg-transparent hover:text-gray-700 hover:dark:text-gray-700">
            <FontAwesomeIcon icon={faGear} />
          </Button>
        </DialogTrigger>
        <DialogContent className="sm:max-w-[450px] sm:max-h-[90vh]">
          <DialogHeader>
            <DialogTitle>Companies Manager</DialogTitle>
            <DialogDescription>
              Make changes to your profile here. Click save when youre done.
            </DialogDescription>
          </DialogHeader>

          {/* Content */}
          <Table>
            <TableHeader>
              <TableRow>
                <TableHead>Name</TableHead>
                <TableHead >Action</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              <TableRow>
                <TableCell>Theme</TableCell>
                <TableCell>
                  <Select onValueChange={(value: Themes) => setTheme(value)}>
                    <SelectTrigger className="w-full">
                      <SelectValue placeholder={theme} />
                    </SelectTrigger>
                    <SelectContent className="border-1 rounded">
                      <SelectItem value="light">Light</SelectItem>
                      <SelectItem value="dark">Dark</SelectItem>
                      <SelectItem value="solarized">Solarized</SelectItem>
                    </SelectContent>
                  </Select>
                </TableCell>
              </TableRow>
            </TableBody>
          </Table>
          {/* End Content */}
        </DialogContent>
      </form>
    </Dialog>
  );
}
