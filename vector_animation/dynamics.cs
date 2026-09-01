using System.Dynamic;

namespace vector_animation;

public class StdDynamic : DynamicObject {
	private OrderedDictionary<string, object> props = new OrderedDictionary<string, object>();

	public override bool TryGetMember (GetMemberBinder binder, out object result) {
		string name = binder.Name.ToLower();
		return props.TryGetValue(name, out result);
	}

	public override bool TrySetMember (SetMemberBinder binder, object value) {
		props[binder.Name.ToLower()] = value;

		return true;
	}
}