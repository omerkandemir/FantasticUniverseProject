FROM node:18

WORKDIR /usr/src/app

COPY package*.json ./
RUN npm install
RUN npm install -g serve 
COPY . .

CMD ["npx", "serve", "-s", "."]
