using vector_animation.utils;

namespace vector_animation;

public static partial class VAS {
	public static class Lexer {
		public static class ContextTracker {
			public enum ContextGeneral {
				topLevel,

				UResourceDef,
				ResourceDefGeneric,
				ResourceDefVector,

				UInstructionDef,
			}

			public enum ContextScope {
				//topLevel,
				standard,

				nameString,
				stdString,

				typelessList,
			}

			public static DynamicArray<ContextGeneral> general = new(ContextGeneral.topLevel);
			public static ContextScope scope = ContextScope.standard;
		}

		

		public static string[] Stage1 (string file) {
			SwitchBlock<char> initiatorSwitch = new(['@','#'], [
				() => ContextTracker.general.Push(ContextTracker.ContextGeneral.UResourceDef),
				() => ContextTracker.general.Push(ContextTracker.ContextGeneral.UInstructionDef)
			]);
			string[] tokens = {};

			
			for (int pt = 0; pt < file.Length; pt++) {
				ContextTracker.ContextGeneral currentContext = ContextTracker.general.GetLastItem();
				char currentChar = file[pt];
				switch (currentContext) {
					case ContextTracker.ContextGeneral.topLevel:
						initiatorSwitch.Exec(currentChar);
					break;
				}
			}
			return tokens;
		}

		public static string[] Stage2 (string[] initTokens) {
			string[] working = {};
			return working;
		}
	}
	

	public static class Parser {
		public class SyntaxTree /*: StdDynamic */ {
			public SyntaxTree (string[] tokens) {
				
			}
		}
	}

	public static Parser.SyntaxTree CreateSyntaxTree (string file) {
		return new Parser.SyntaxTree(Lexer.Stage2(Lexer.Stage1(file)));
	}
}