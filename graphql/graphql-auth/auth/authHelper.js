import config from "./config.json";
import jwt from "jsonwebtoken";
import { execDatabaseQuery } from "../data/db.js";

const signKey = config.jwt.signKey;

export const generateJwtToken = async (user) => {
  return await execDatabaseQuery(async (connection) => {
    const u = await connection
      .collection("users")
      .findOne({ email: user.email, password: user.password });

    if (!u) {
      return "";
    }

    return jwt.sign(
      {
        name: u.name,
        email: u.email,
      },
      signKey
    );
  });
};

export const convertJwtToUser = (token) => {
  // Verify
  try {
    const user = jwt.verify(token, signKey);
    return {
      name: user.name,
      email: user.email,
    };
  } catch (e) {
    throw Error(e);
  }
};
