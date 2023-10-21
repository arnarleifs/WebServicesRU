import "./globals.css";
import type { Metadata } from "next";
import { UserProvider } from "@auth0/nextjs-auth0/client";
import { Inter } from "next/font/google";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "Auth0 Login",
  description: "",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html className="h-full bg-white" lang="en">
      <UserProvider>
        <body className={`${inter.className} h-full`}>{children}</body>
      </UserProvider>
    </html>
  );
}
