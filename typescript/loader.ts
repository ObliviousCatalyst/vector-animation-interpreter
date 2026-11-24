// import { drawPoly } from "./render.js"
// import { dotnet } from "./vector_animation/bin/Release/net10.0/browser-wasm/publish/dotnet.js"
// @ts-ignore -- generated .NET runtime module has no TypeScript declarations
// import { dotnet } from "./vector_animation/bin/Release/net10.0/browser-wasm/publish/dotnet.js"
// import { dotnet } from ".vector_animation/obj/Release/net10.0/dotnet.js"
import { dotnet } from "../vector_animation/bin/Release/net10.0/wwwroot/_framework/dotnet.js"

//C:\Users\jackc\Documents\GitHub\vector-animation-interpreter\vector_animation\obj\Release\net10.0\dotnet.js
//vector_animation\bin\Release\net10.0\wwwroot\_framework\dotnet.js

interface DotnetModule {
	getConfig: Function
}

export interface dotnetex {
	vector_animation: {
		JSInterop: {
			NewVectorAsset (vasFile: string): void
		}
	}
}

export async function load () {
	const lib = await dotnet.withDiagnosticTracing(false).create()

	console.log(lib)

	const cfg = lib.getConfig()
	const exports: dotnetex = await lib.getAssemblyExports(cfg.mainAssemblyName!)

	console.log(exports)

}

load()

// import fs from "node:fs"
// const file = fs.readFileSync("./vector_animation/bin/Release/net10.0/browser-wasm/publish/dotnet.js", "utf-8")
// console.log("file:", file)