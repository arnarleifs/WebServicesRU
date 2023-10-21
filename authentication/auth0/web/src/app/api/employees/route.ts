import { getAccessToken } from "@auth0/nextjs-auth0";

export async function POST(request: Request) {
  const body = await request.json();
  const { accessToken } = await getAccessToken();

  await fetch(`${process.env.API_BASE_URL}/employees`, {
    method: "POST",
    headers: {
      Authorization: `Bearer ${accessToken}`,
      "Content-Type": "application/json",
    },
    body: JSON.stringify(body),
  });
  return Response.json({});
}

export async function GET() {
  const { accessToken } = await getAccessToken();

  const result = await fetch(`${process.env.API_BASE_URL}/employees`, {
    headers: {
      Authorization: `Bearer ${accessToken}`,
    },
  });
  return Response.json(await result.json());
}
