using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace vector_animation;

public static partial class JSInterop {
	public enum CanvasMode {
		fallback,
		webgpu
	}

	public static CanvasMode mode = CanvasMode.fallback;

	// example so that i remember how to do this later
	[JSImport("PLACEHOLDER")]
	public static partial void PLACEHOLDER ([JSMarshalAs<JSType.Function<JSType.Number>>]Action<float> callback);

	[JSImport("requestList")]
	public static partial void Emit ();

	// the param must be a double[]. i don't know why but my IDE yells at me if i use float[]
	// [JSImport("drawPoly")]
	// public static partial void DrawPoly ([JSMarshalAs<JSType.Array<JSType.Number>>] double[] coords);
	
	[JSExport]
	public static void PassFunctions (string funcName, [JSMarshalAs<JSType.Function<JSType.String>>] Action<string> function) {
		Action<object> wrapperFunc = doubles => {
			string jsonString = JsonSerializer.Serialize(doubles);
			function(jsonString);
		};
	}

	[JSExport]
	public static void ChangeMode (string modeString) {
		mode = modeString switch {
			"webgpu" => CanvasMode.webgpu,
			_ => CanvasMode.fallback,
		};
	}

	[JSExport]
	public static void NewVectorAsset (string vasFile) {

	}

	// [JSExport]
	// public static JSObject getCurrentState () {
	// 	JSObject obj = new();
	// }

	// [JSExport]
	// public static void CreateAnimMod (
	// 	Action<float[]> drawPoly
	// ) {
	// 	AnimodMethods methods = new()
	// 	{
	// 		DrawPoly = drawPoly
	// 	};
	// }
}

// [JsonSerializable(typeof(double[]))]
// internal partial class JSInteropJsonContext : JsonSerializerContext { }