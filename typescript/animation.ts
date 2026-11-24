export class Animation {
	static modes = Object.freeze({
		// these numbers do not matter whatsoever
		// we're essentially just fudging an enum so in theory they can be anything
		canvas2d: 69,
		webgpu: 420,
	})

	static modesarr = Object.freeze([CanvasContext.modes.canvas2d, CanvasContext.modes.webgpu])
	
	#mode = null

	get mode () {
		if (this.#mode === CanvasContext.modes.webgpu) return "webgpu"
		return "canvas2d"
	}

	/** @type {HTMLCanvasElement} */
	#canvas = null

	/** @type {HTMLCanvasElement} */
	get canvas () {
		return this.#canvas
	}

	set canvas (param) {
		if (this.#canvas === null && param instanceof HTMLCanvasElement) {
			this.canvas = param
		}
	}	
	
	canvas2d = null
	webgpu = null

	setMode (mode) {
		if (this.#mode === null) {
			console.error("render mode has already been set and we don't know how to change it after initialization")
			return
		}
		if (CanvasContext.modesarr.includes(mode)) {
			this.#mode = mode
			switch (this.#mode) {
				case CanvasContext.modes.canvas2d: 
					this.canvas2d = this.#canvas.getContext("2d")
				break

				case CanvasContext.modes.webgpu:
					this.webgpu = this.canvas.getContext("webgpu")
				break
			}
			return
		}
		if (CanvasContext.modes[mode]) { 
			this.#mode= CanvasContext.modes[mode]
			return
		}
		console.error(`you can't set VA render mode to "${mode}" dumbass`)
	}
}