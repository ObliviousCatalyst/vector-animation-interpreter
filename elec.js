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
	".json": "application/json",
	".wasm": "application/wasm",
	".pdb": "application/vnd.palm",
	".map": "text/plain"
})

function getMimeType (ext) {
	let type = mimeTypes[ext]
	console.log(type)
	if (type === undefined) {
		type = "application/octet-stream"
	}
	console.log(type)
	return type
}

server.on("request", async (req, res) => {
	let ext = path.parse(req.url).ext ?? ".js"
	console.log(ext)
	res.setHeader("Content-type", getMimeType(ext))

	let filepath = path.join(dirname, req.url)
	
	console.log(filepath)
	res.write(await fs.promises.readFile(filepath))
	res.end()
})

server.listen(8000)

app.on("ready", () => {
	const window = new BrowserWindow()
	window.loadURL("http://127.0.0.1:8000/main.html")
})