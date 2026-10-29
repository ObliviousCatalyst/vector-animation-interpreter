namespace vector_animation.utils;

public class SwitchBlock <keyType> where keyType : notnull {
	public Dictionary<keyType, Action> functions = [];
	
	public SwitchBlock (keyType[] keys, Action[] voids) {
		if (keys.Length != voids.Length) {
			throw new Exception("length of keys and voids do not match");
		}
		for (int pt = 0; pt < keys.Length; pt++) {
			functions[keys[pt]] = voids[pt];
		}
	}

	public void Exec (keyType key) {
		functions.TryGetValue(key, out Action? func);
		func?.Invoke();
	}
}

// public class StdDynamic  {
// 	private OrderedDictionary <string, object> props = new OrderedDictionary<string, object>();

// 	public override bool TryGetMember (GetMemberBinder binder, out object? result) {
// 		string name = binder.Name.ToLower();
// 		return props.TryGetValue(name, out result);
// 	}

// 	public override bool TrySetMember (SetMemberBinder binder, object? value) {
// 		props[binder.Name.ToLower()] = value!; // vscode told me to put this exclamation mark here but i don't knwow what it does

// 		return true;
// 	}
// }

public class DynamicArray <mainType> {
	public int length {
		get {
			return internalArray.Length;
		}
	}
	// public int lastIndex {get;} = 0;
	public bool
	fixedSize = false,
	oobAsNull = false;
	protected mainType?[] internalArray;

	public DynamicArray () {
		internalArray = [];
	}

	public DynamicArray (params mainType?[] initialArray) {
		internalArray = initialArray;
	}

	public DynamicArray (mainType?[] initialArray, bool isFixed, bool returnOobAsNull) {
		internalArray = initialArray;
		fixedSize = isFixed; 
		oobAsNull = returnOobAsNull;
	}

	public mainType? this[int index] {
		get {
			if (oobAsNull && index >= internalArray.Length) {
				return default;
			}
			return internalArray[index];
		}

		set { 
			internalArray[index] = value;
		}
	}

	public void Extend (int newLength) {
		Array.Resize(ref internalArray, newLength);
	}

	public void Extend () {
		Extend(internalArray.Length + 1);
	}

	public int GetLastOpenIndex () {
		int ix = 0;
		for (int pt = 0; pt < internalArray.Length; pt++) {
			if (internalArray[pt] != null) {
				ix = pt + 1;
			}
		}
		return ix;
	}

	public int GetLastFilledIndex () {
		return GetLastOpenIndex() - 1;
	}

	public mainType? GetLastItem () {
		return this[GetLastFilledIndex()];
	}

	public void Push (mainType? item) {
		int last = GetLastOpenIndex();
		if (last == internalArray.Length) {
			Extend();
		}
		internalArray[last] = item;
	}

	public mainType? Pop () {
		int last = GetLastOpenIndex();
		mainType? temp = internalArray[last];
		internalArray[last] = default;
		return temp;
	}
}