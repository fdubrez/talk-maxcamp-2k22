// credits https://developer.mozilla.org/en-US/docs/Learn/Server-side/Node_server_without_framework
import * as fs from "node:fs";
import * as http from "node:http";
import { url } from "node:inspector";
import * as path from "node:path";
import config from "./config.json" assert { type: "json" };
import project from "./package.json" assert { type: "json" };

const PORT = process.env.PORT || 8000;

const SERVICES = {};
config.services.forEach(({ name, url }) => {
  SERVICES[name] = {
    name,
    url,
    status: null,
  };
});

const MIME_TYPES = {
  default: "application/octet-stream",
  html: "text/html; charset=UTF-8",
  js: "application/javascript; charset=UTF-8",
  css: "text/css",
  png: "image/png",
  jpg: "image/jpg",
  gif: "image/gif",
  ico: "image/x-icon",
  svg: "image/svg+xml",
};

const STATIC_PATH = path.join(process.cwd(), "./static");

const toBool = [() => true, () => false];

const prepareFile = async (url) => {
  const paths = [STATIC_PATH, url];
  if (url.endsWith("/")) paths.push("index.html");
  const filePath = path.join(...paths);
  const pathTraversal = !filePath.startsWith(STATIC_PATH);
  const exists = await fs.promises.access(filePath).then(...toBool);
  const found = !pathTraversal && exists;
  const streamPath = found ? filePath : STATIC_PATH + "/404.html";
  const ext = path.extname(streamPath).substring(1).toLowerCase();
  const stream = fs.createReadStream(streamPath);
  return { found, ext, stream };
};

let clients = [];

function sendEventsToAll() {
  clients.forEach((client) =>
    client.response.write(`data: ${JSON.stringify(SERVICES)}\n\n`)
  );
}

async function fetchServicesStatus() {
  await Promise.all(config.services.map(async ({name, url}) => {
    try {
      const res = await fetch(url)
      console.log(`GET ${url} ${res.status}`)
      SERVICES[name].status = res.status
    } catch (err) {
      console.error(`GET ${url} ${err.message}`)
      SERVICES[name].status = -1
    }
  }))
  sendEventsToAll()
  setTimeout(fetchServicesStatus, config.interval);
}
fetchServicesStatus()

function eventsHandler(request, response) {
  const headers = {
    "Content-Type": "text/event-stream",
    Connection: "keep-alive",
    "Cache-Control": "no-cache",
  };
  response.writeHead(200, headers);

  const data = `data: ${JSON.stringify(SERVICES)}\n\n`;

  response.write(data);

  const clientId = Date.now();

  const newClient = {
    id: clientId,
    response,
  };

  clients.push(newClient);

  request.on("close", () => {
    console.log(`${clientId} Connection closed`);
    clients = clients.filter((client) => client.id !== clientId);
  });
}

http
  .createServer(async (req, res) => {
    if (req.url.endsWith("/health")) {
      res.writeHead(200, { "Content-Type": "application/json" });
      res.write(
        JSON.stringify({
          name: project.name,
          version: project.version,
          clients: clients.length,
        })
      );
      res.end();
    } else if (req.url.endsWith("/events")) {
      eventsHandler(req, res);
    } else {
      const file = await prepareFile(req.url);
      const statusCode = file.found ? 200 : 404;
      const mimeType = MIME_TYPES[file.ext] || MIME_TYPES.default;
      res.writeHead(statusCode, { "Content-Type": mimeType });
      file.stream.pipe(res);
      console.log(`${req.method} ${req.url} ${statusCode}`);
    }
  })
  .listen(PORT);

console.log(`Server running at http://127.0.0.1:${PORT}/`);
