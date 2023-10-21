/** @type {import('next').NextConfig} */
const nextConfig = {
  images: {
    remotePatterns: [
      {
        protocol: "https",
        hostname: "www.drupal.org",
        port: "",
        pathname: "/files/**",
      },
    ],
  },
};

module.exports = nextConfig;
