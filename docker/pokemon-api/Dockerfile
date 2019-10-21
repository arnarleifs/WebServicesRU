FROM node:latest
LABEL maintainer="Arnar Leifsson"

ENV NODE_ENV production

ENV DBHOST pokemon-db
ENV DBNAME pokemon

COPY . /app
WORKDIR /app
RUN npm install

ENTRYPOINT [ "npm", "run", "build" ]
