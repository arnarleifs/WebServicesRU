FROM node:latest

LABEL maintainer="Arnar Leifsson"

COPY . /app
WORKDIR /app

RUN npm install

ENTRYPOINT [ "npm", "run", "build" ]
