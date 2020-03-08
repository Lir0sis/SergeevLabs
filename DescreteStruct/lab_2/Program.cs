using System;
using Hashmap;

namespace lab_2 {
	
	
	class Program {
		static void Main() {
			var map = new HashmapClosed<string, string>(512);
			map.Add("Oleg", "Valentina");
			map.Add("Valentine", "Olga");
			Console.WriteLine("Oleg -> " + map.Find("Oleg").Value);
			Console.ReadKey();
		}
	}
}
