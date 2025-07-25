
import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  output: 'export',
  assetPrefix: './', // 👈 خلي المسارات تبدأ بـ ./ بدل /./
  trailingSlash: true,
  images: {
    unoptimized: true,
    domains: ['shared.fastly.steamstatic.com'],
  },
};

export default nextConfig;