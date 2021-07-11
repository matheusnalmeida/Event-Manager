FROM node:alpine

# set the working direction
WORKDIR /app

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY package.json /app/package.json

COPY package-lock.json /app/package-lock.json

RUN npm install

# add app
COPY . /app

# start app
CMD ["npm", "start"]