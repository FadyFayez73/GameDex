import FuzzyText from "@/components/reactbits/FuzzyText/FuzzyText";
import { useTheme } from "@/components/contexts/theme-provider";

function NotFound() {
  const { theme } = useTheme();
  return (
    <div className="w-full h-full flex items-center justify-center">
      <FuzzyText
        color={theme === "dark" ? "#fff" : "#000"}
        baseIntensity={0.2}
        hoverIntensity={0.5}
        enableHover={true}
      >
        Not Found
      </FuzzyText>
    </div>
  );
}

export default NotFound;
