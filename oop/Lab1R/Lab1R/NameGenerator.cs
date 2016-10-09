﻿using System;
using System.Diagnostics;

namespace Lab1R
{
	public class NameGenerator
	{
		#region Names
		private static readonly string[] names = {
			"Gregory",
			"Mihail",
			"Vlad",
			"Sergei",
			"Niko",
			"Dimon",
			"Tony",
			"Petr",
			"Vitya",
			"Jenia",
			"Oleg",
			"Nazar",
			"Anatolij",
			"James",
			"Ben",
			"Andrei",
			"Ivan",
			"Pedro",
			"John",
			"Max",
			"Kama",
			"ObiVan",
			"Luke",
			"Darth",
			"Magistr",
			"Doge",
			"Pepe",
			"Roman",
			"Michael",
			"Trevor",
			"Mr",
			"Admiral",
			"Lieutenant",
			"Satoshi",
			"Isran",
			"Arthas"
		};
		private static readonly string[] surnames = {
			"Faustin",
			"Bellik",
			"Frai",
			"Rudenko",
			"Montana",
			"Bond",
			"Pushkin",
			"Laden",
			"Korolev",
			"Gagarin",
			"Koshechkin",
			"Ivanov",
			"Doe",
			"Progulkin",
			"Pupkin",
			"Sveklov",
			"Arbuzov",
			"Payne",
			"Android",
			"The Bullet",
			"The Strong",
			"The Smart",
			"The Fearless",
			"The Frog",
			"Johnson",
			"Torvalds",
			"Philips",
			"Sharapov",
			"Oslov",
			"Nakamoto",
			"Smartypants",
			"Zahaev",
			"Menethyl",
			"Gordon",
		};
		#endregion

		private static readonly string[] namePairs;
		private static Random rnd = new Random();
		private static int currName;

		private static void shuffleNamePairs(){
			int n = namePairs.Length;
			while (n > 1) {
				int k = rnd.Next (n);
				n--;
				string tmp = namePairs [k];
				namePairs [k] = namePairs[n];
				namePairs [n] = tmp;
			}
		}

		static NameGenerator ()
		{
			int len = names.Length * surnames.Length;
			namePairs = new string[len];
			int pos = 0;
			foreach (var name in names)
				foreach (var surname in surnames)
					namePairs [pos++] = name + " " + surname;
			Debug.Assert (pos == len);
			shuffleNamePairs ();
		}

		public static string NextName(){
			string res = namePairs [currName++];
			currName %= namePairs.Length;
			return res;
		}
	}
}