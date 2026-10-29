using System.Runtime.InteropServices.JavaScript;
using vector_animation.utils;

namespace vector_animation;

public static partial class VAS {
	public static partial class Lexer {
		public static class SpecialChars {
			public static readonly char[] 
			whitespace = [' ','\t','\n'],
			separators = [',','.',':',';'],
			operators = ['!','@','#','$','%','&','+','-','*','/','\\','~'],
			delimiters = ['(',')','[',']','{','}','\"','\'','>','<'];
			
			public static bool CheckInGroup (char input, char[] group) {
				bool result = false;
				foreach (char character in group) {
					if (input == character) {
						result = true;
					}
				}
				return result;
			}

			public static bool IsWhitespace (char input) {
				return CheckInGroup(input, whitespace);
			}

			public static bool IsSeparator (char input) {
				return CheckInGroup(input, separators);
			}

			public static bool IsOperator (char input) {
				return CheckInGroup(input, operators);
			}

			public static bool IsDelimiter (char input) {
				return CheckInGroup(input, delimiters);
			}

			public static bool IsSpecial (char input) {
				return IsWhitespace(input) || IsOperator(input) || IsSeparator(input) || IsDelimiter(input);
			}
		} 
		
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
				property,

				nameString,
				stdString,

				typelessList,
			}

			public static DynamicArray<ContextGeneral> general = new(ContextGeneral.topLevel);
			public static ContextScope scope = ContextScope.standard;
		}

		
		//[JSExport]
		public static DynamicArray<string> Tokenize (string file) {
			string iToken = "";
			DynamicArray<string> tokens = new();
			
			SwitchBlock<char> initiatorSwitch = new(['@','#'], [
				() => ContextTracker.general.Push(ContextTracker.ContextGeneral.UResourceDef),
				() => ContextTracker.general.Push(ContextTracker.ContextGeneral.UInstructionDef)
			]);

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