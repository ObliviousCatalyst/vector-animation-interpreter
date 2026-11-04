import http from "node:http"
import fs from "node:fs"
import path from "node:path"
import { app, BrowserWindow } from "electron"
const dirname = import.meta.dirname

const server = http.createServer()

const mimeTypes = Object.freeze({
	".html": "text/html",
	".css": "text/css",
	".js": "text/javascript",
	".wasm": "application/wasm",
})

server.on("request", async (req, res) => {
	let ext = path.parse(req.url).ext
	let filepath = path.join(dirname, req.url)
	res.setHeader("Content-type", mimeTypes[ext])
	console.log(filepath)
	res.write(await fs.promises.readFile(filepath))
	res.end()
})

server.listen(8000)

app.on("ready", () => {
	const window = new BrowserWindow()
	window.loadURL("http://127.0.0.1:8000/main.html")
})