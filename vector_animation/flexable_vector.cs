namespace vector_animation;

public class FlexVector {
	private object[] raw;
	public object this[int index] {
		get {
			return raw[index];
		}

		set {
			raw[index] = value;
		}
	}

	public FlexVector (params object[] vals) {
		raw = vals;
	}
}

public class PositionalVector : FlexVector {
	public float x;
	public float y;

	public PositionalVector (params float[] axis) : base(axis) {
		this.x = axis[0];
		this.y = axis[1];
	}
}

public class RGBVector : FlexVector {
	public int r;
	public int g;
	public int b;
	public int a;
	public int[] alpha = {};

	public RGBVector (params int[] channels) : base(channels) {
		this.r = channels[0];
		this.g = channels[1];
		this.b = channels[2];
		this.a = channels[3];
		for (int index = 4; index < channels.Length; index++) {
			Array.Resize(ref alpha,channels.Length - 4);
			this.alpha[index - 4] = channels[index];
		}
	}
}
