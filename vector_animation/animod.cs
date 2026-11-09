using vector_animation.utils;
using vector_animation.FlexibleVectors;
using System.Reflection;

namespace vector_animation;

public static class GlobalAnimations {
	private static DynamicArray<AnimationModule> animations = new();
	
	public static AnimationModule NewAnimMod (AnimodMethods methods) {
		animations.Push(new());
		return animations.GetLastItem()!;
	}
}



public class AnimationModule {
	public static readonly Dictionary<string,Type> functionTypes;
	
	public class AnimodMethods {
		public static class Util {
			public static Type GetActionType (string name) {
				return (typeof(AnimodMethods).GetField(name) ?? typeof(Util).GetField("dummyType")!).FieldType;
			}

			private static readonly Action dummyType = () => {};
		}

		public Action<float[]> DrawPoly = (float[] floats) => {};
	}

	public ulong frame = 0;
	public uint frameRate;

	public Action<float[]> DrawPoly;

	public AnimationModule (uint framerate, AnimodMethods methods) {
		frameRate = framerate;
		DrawPoly = methods.DrawPoly;
	}

	public AnimationModule (AnimodMethods methods): this(60, methods) {}
		
	public AnimationModule (): this(new()) {}

	public void play () {

	}
}