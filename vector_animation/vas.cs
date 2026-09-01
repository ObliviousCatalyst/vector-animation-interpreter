using System.Dynamic;
using Microsoft.VisualBasic;
namespace vector_animation;

public static class VAS {
	public static string[] Tokenise (string file) {
		int pt;
		char[] temp = {};
		string[] working = {};
		string[] final = {};

		void recordString () {
			if (temp.Length > 0) {
				Array.Resize(ref working, working.Length + 1);
				working[working.Length - 1] = new string(temp);
				temp = [];
			}
		}

		void recordChar() {
			Array.Resize(ref temp, temp.Length + 1);
			temp[temp.Length - 1] = file[pt];
		}

		for (pt = 0; pt < file.Length; pt++) {
			switch (file[pt]) {
				case ' ':
				case '\n':
				case '\t':
					recordString();
				break;

				case '@':
				case '#':
				case '!':
				case '{':
				case '}':
				case '[':
				case ']':
				case '(':
				case ')':
				case ':':
				case ',':
					recordString();
					recordChar();
					recordString();
				break;
				
				case '"':
				case '\'':
				case '`':
					char del = file[pt];
					recordString();
					recordChar();
					recordString();
					pt++;
					while (pt < file.Length && file[pt] != del) {
						recordChar();
						pt++;
					}
					recordString();
					recordChar();
					recordString();
				break;

				default: 
					recordChar();
				break;
			}
			Console.WriteLine(string.Join(",",working));
		}
		return working;
	}

	public class Construct {

		class Resource {
			public Resource () {

			}
		}

		class Instruction {
			public Instruction () {
				
			}
		}

		StdDynamic resourceList = new();
		StdDynamic instructionList = new();
		
		public Construct (string[] vasArray) {
			for (int pt = 0; pt < vasArray.Length; pt++) {

			}
		}
	}
}