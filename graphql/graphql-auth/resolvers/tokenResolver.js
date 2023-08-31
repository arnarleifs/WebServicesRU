import { generateJwtToken } from "../auth/authHelper.js";

export default {
  mutations: {
    generateToken: async (parent, args, context) => {
      const token = await generateJwtToken(args.user);
      console.log(token);
      return token;
    },
  },
};
