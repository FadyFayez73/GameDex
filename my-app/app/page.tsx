"use client";

// import { useState } from "react";

// Pages
import Library from "@/components/features/Library/page";

// Contexts
// import { useTheme } from "@/components/contexts/theme-provider";

export default function Home() {
  return (
    <div className="w-screen h-screen flex flex-row font-sans">
      {/* Library */}
      <div className="w-full h-full">
        <Library />
      </div>
    </div>
  );
}
