## Context

Project created for an internal Tech conference at Max Digital Services.

The objective was to code a project in multiple language/runtinmes with no external libraries to compare them.

## Getting started

### Slides

Slides are written in markdown in `prez/slides.md` and run using [slidev](https://sli.dev/). 

```shell
cd prez
npm install 
npm run dev
```

### API

The API is a dotnet core HTTP server that perform the image manipulation.

```shell
cd api/dotnet/withlib
# start server on default port 8080
dotnet run
# start server on custom port 8090
PORT=8090 dotnet run
```

### Website

```shell
cd code/siteweb
npx live-server
```

### CLI

The goal of that conference was to compare the development of a CLI tool in many languages using only the standard library.

It should use this contract `peachme [-h|--help] <source image file>` and create an `/tmp/output.png` output file and open it using `open` command (Mac OS).

#### Bash

```shell
./code/cli/bash/peachme prez/images fdu_ready.png
```

#### Dotnet

```shell
cd code/cli/dotnet
dotnet build
./bin/Debug/net6.0/dotnet ../../../prez/images fdu_ready.png
```

#### Java

```shell
./code/cli/java/peachme prez/images fdu_ready.png
```

#### Node

```shell
./code/cli/node/peachme prez/images fdu_ready.png
```

#### Python

```shell
./code/cli/node/peachme prez/images fdu_ready.png
```

### Status website

#### uptime-kuma

Github project: https://github.com/louislam/uptime-kuma

You can either use the docker image or clone the project and run it locally.

#### vanilla status website

```shell
cd code/status/node
node server.mjs
```

* URLs to check are configured in `code/status/node/config.json` file.
* Real time data is pushed to all clients connected using SSE (Server Sent Event).

## License

Copyright © 2022 François Dubrez
This work is free. You can redistribute it and/or modify it under the
terms of the [Do What The Fuck You Want To Public License](http://www.wtfpl.net/), Version 2,
as published by Sam Hocevar. See the [LICENSE](LICENSE) file for more details.

![WTFPL](http://www.wtfpl.net/wp-content/uploads/2012/12/logo-220x1601.png)