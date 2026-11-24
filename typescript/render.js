export function drawPoly (...coords) {
	
	for (let pt = 0; pt < Math.floor(coords.length / 2); pt++) {
		console.log(coords[pt],coords[pt + 1])
	}
}