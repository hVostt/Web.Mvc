using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace hVostt.Web.Mvc.Translit
{


	public class Metagraphy
	{
		private readonly Dictionary<char, string> _table = new Dictionary<char, string>(50);
		private readonly List<Tuple<string, string>> _special = new List<Tuple<string, string>>(10);

		public Metagraphy()
		{
			AddFriendlyUrlChars(true);
		}

		public void AddBaseChars()
		{
			Add('а', "a");
			Add('б', "b");
			Add('в', "v");
			Add('г', "g");
			Add('д', "d");
			Add('е', "e");
			Add('з', "z");
			Add('к', "k");
			Add('л', "l");
			Add('м', "m");
			Add('н', "n");
			Add('о', "o");
			Add('п', "p");
			Add('р', "r");
			Add('с', "s");
			Add('т', "t");
			Add('у', "u");
			Add('ф', "f");
		}

		public void AddIso9Chars(bool withBase = false)
		{
			if (withBase)
				AddBaseChars();
			Add('ё', "yo");
			Add('ж', "zh");
			Add('и', "i");
			Add('й', "j");
			Add('х', "x");
			Add('ц', "c");
			Add('ч', "ch");
			Add('ш', "sh");
			Add('щ', "shh");
			Add('ь', "`");
			Add('ъ', "``");
			Add('ы', "y`");
			Add('э', "e`");
			Add('ю', "yu");
			Add('я', "ya");
		}

		public void AddFriendlyUrlChars(bool withBase = false)
		{
			if (withBase)
				AddBaseChars();
			Add(' ', "-");
			Add('-', "-");
			Add('ё', "e");
			Add('ж', "zh");
			Add('и', "i");
			Add('й', "y");
			Add('х', "h");
			Add('ц', "ts");
			Add('ч', "ch");
			Add('ш', "sh");
			Add('щ', "shch");
			Add('ь', "");
			Add('ъ', "");
			Add('ы', "y");
			Add("ый", "iy");
			Add('э', "e");
			Add('ю', "yu");
			Add('я', "ya");
		}

		public void Add(char pattern, string replace)
		{
			_table[pattern] = replace;
		}

		public void Add(string pattern, string replace)
		{
			if (String.IsNullOrEmpty(pattern))
				throw new ArgumentException("Pattern should not be empty", "pattern");
			_special.Add(new Tuple<string, string>(pattern, replace));
		}

		private static bool IsBasicChar(char c)
		{
			return Char.IsDigit(c) || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
		}

		public string CleanUrlPart(string src)
		{
			src = src.ToLower();
			var builder = new StringBuilder();
			for (var i = 0; i < src.Length; ++i)
			{
				var c = src[i];
				if (IsBasicChar(c)) builder.Append(c);
				else
				{
					Replace(src, i, builder);
				}
			}
			return builder.ToString();
		}

		private bool Match(string src, int index, string sample)
		{
			for (var i = 0; i < sample.Length; ++i)
			{
				var j = index + i;
				if (j >= src.Length || src[j] != sample[i])
					return false;
			}
			return true;
		}

		private void Replace(string src, int index, StringBuilder builder)
		{
			foreach (var tuple in _special)
			{
				if (Match(src, index, tuple.Item1))
				{
					builder.Append(tuple.Item2);
					return;
				}
			}
			string s;
			if (_table.TryGetValue(src[index], out s))
			{
				builder.Append(s);
			}
		}
	}
}
