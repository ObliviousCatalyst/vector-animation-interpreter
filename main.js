import { drawPoly } from "./render.js"
// import { dotnet } from "./vector_animation/bin/Release/net10.0/browser-wasm/publish/dotnet.js"
import { dotnet } from "./vector_animation_lib/bin/Release/net10.0/dotnet.js"
const lib = await dotnet.withDiagnosticTracing(false).create()

console.log(lib)

const cfg = lib.getConfig()
const exports = lib.getAssemblyExports(cfg.mainAssemblyName)

console.log(exports)

// import fs from "node:fs"
// const file = fs.readFileSync("./vector_animation/bin/Release/net10.0/browser-wasm/publish/dotnet.js", "utf-8")
// console.log("file:", file)