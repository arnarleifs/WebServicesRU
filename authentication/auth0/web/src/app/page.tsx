import { LinkButton } from "@/components/link-button/link-button";
import { withPageAuthRequired, getSession } from "@auth0/nextjs-auth0";
import Link from "next/link";

export default withPageAuthRequired(async function Profile() {
  const session = await getSession();
  return (
    <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8">
      <div className="flex flex-col sm:mx-auto sm:w-full sm:max-w-sm gap-10 items-center">
        <h1>Hello. {session?.user.name}</h1>
        <LinkButton href="/employees">Employees page</LinkButton>
      </div>
    </div>
  );
});
