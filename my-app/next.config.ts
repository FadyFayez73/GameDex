import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  // output: 'export',
  // assetPrefix: './',
  // trailingSlash: true,
  images: {
    unoptimized: false, // خلي التحسينات شغالة
    remotePatterns: [
      {
        protocol: 'https',
        hostname: 'shared.fastly.steamstatic.com',
        pathname: '/store_item_assets/steam/apps/**',
      },
    ],
  },
};

export default nextConfig;
