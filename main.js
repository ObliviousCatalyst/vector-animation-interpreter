import { dotnet } from "./vector_animation/bin/Release/net10.0/wwwroot/_framework/dotnet.js"

export async function loadModule () {
	const lib = await dotnet.withDiagnosticTracing(false).create()

	// console.log(lib)

	const cfg = lib.getConfig()
	const exports = await lib.getAssemblyExports(cfg.mainAssemblyName)

	// console.log(exports)

	return exports.vector_animation.JSInterop
}

let mod = await loadModule()

console.log(mod)

// import fs from "node:fs"
// const file = fs.readFileSync("./vector_animation/bin/Release/net10.0/browser-wasm/publish/dotnet.js", "utf-8")
// console.log("file:", file)