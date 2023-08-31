import { convertJwtToUser } from "../auth/authHelper.js";

export default async ({ req }) => {
  const authorizationHeader = req.headers["authorization"];
  if (!authorizationHeader) {
    return;
  }
  const token = authorizationHeader.replace("Bearer ", "");

  const user = convertJwtToUser(token);

  return {
    currentUser: user,
  };
};
