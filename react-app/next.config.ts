import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  images: {
    unoptimized: true,
    domains: ["shared.fastly.steamstatic.com"],
  },
  output: 'export'
};

export default nextConfig;
