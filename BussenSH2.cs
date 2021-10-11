using System;

namespace Bussen
{
	class BussenSH2
	{
		const int maxPassengers = 25; // Ett låst fält till 25 som håller koll på max antal passagerare
		public int currentPassengers = 0; // Variabel som håller koll på nuvarande antal passagerare i bussen
		public int[] passengers = new int[maxPassengers]; // Vektor där vi lagrar passagerarnas ålder

		// Har lagt flera Console.clear(); lite här och var för att snygga upp menyn och flödet så det ser rent och fint ut!

		public void Run()
		{
			string menu = "0"; // Valde att använda datatypen string istället för int, då slipper jag en try / catch över menyn

			do // Loopar menyn så länge while villkoret nedan stämmer
			{
				Console.WriteLine("==== Welcome to the awesome Bus-simulator ====" +
					"\n1. Add passengers to the bus" +
					"\n2. Age of all the passengers" +
					"\n3. Oldest passenger on the bus" + 
					"\n4. Total age on the bus" +
					"\n5. Avarage age on the passengers" +
					"\n6. Sort the passengers" +
					"\n7. Exit the bus-simulator"+
					"\n==============================================");
				Console.Write("\nMake a choice from 1-7:");
				menu = (Console.ReadLine()); // Läser inmatningen av användaren och styr menyn och sparar värdet i menu

				switch (menu) // Alla metoderna kallas här nedanför 
				{
					case "1": add_passenger();
						break;

					case "2": print_buss();
						break;

					case "3": max_age();
						break;

					case "4": calc_total_age();
						break;

					case "5": calc_average_age();
						break;

					case "6": sort_buss();
						break;

					case "7":
						break;

					default:
						Console.Clear();
						Console.WriteLine("Please only write numbers between 1-7" +
							"\nPress any key to return to the menu..");
						Console.ReadKey();
						break;
				}
				Console.Clear();

			} while (menu != "7"); // Väljer användaren att skriva 7 så kommer loopen och programmet att avslutas

		}

		// Metoden för att lägga till passagerare och och spara deras ålder i vektorn 

		public void add_passenger()
		{
			Console.Clear();
			Console.Write("Type the number of passengers you want to add to the bus:");
			try // Felhantering över hela metoden för att inte användaren ska kunna skriva in annat än en integer samt ett tal över 25
			{
				int addPassenger = int.Parse(Console.ReadLine()); // Lagrar användarens inmatning i variabeln addPassenger

				if(maxPassengers - currentPassengers < addPassenger) // Tar hand om full buss och informerar om antalet tomma platser
                {
					Console.Clear();
					Console.WriteLine($"The bus has 25 seats total, and {maxPassengers - currentPassengers} seats are empty right now!");
					Console.WriteLine("\nPress any key to return to the menu..");
					Console.ReadKey();

				}
				else // Så länge det finns plats på bussen körs detta else block för att spara åldern på passagerarna
				{
					for (int x = 0; x < addPassenger; x++)
					{
						Console.Write($"How old is passenger {1+currentPassengers}:");
						int passengerAge = int.Parse(Console.ReadLine());

						if (passengerAge <= 0 )
						{
							x--; // Stegar tillbaka i vektorn så inga platser skippas eller ersätts när man gått ett varv
							Console.WriteLine("\nTo enter the bus you have to be 1 year or older");
							continue;
						}
						else if (passengerAge >= 122)
						{
							x--;
							Console.WriteLine("\nIf you are this old you have to be Jeanne Calment or a Zombie");
							continue;
						}
						else
						{
							passengers[currentPassengers] = passengerAge; // Sparar användarens värde i vektorns nuvarande plats i loopen
							currentPassengers++; // Adderar en till variabeln currentPassengers och håller koll på antalet passagerare
						}
					}
				}
			}
			catch // Fångar om användaren skrivit in annat än en integer och återgår till menyn
			{
				Console.WriteLine("Can only type numbers between 1-25");
				Console.WriteLine("\nPress any key to return to the menu..");
				Console.ReadKey();
				return; // Returnerar till menyn
			}
		}

		// Metod för att Skriv ut alla värden ur vektorn. (Skriv ut alla passagerare)

		public void print_buss()
		{
		if (currentPassengers == 0)
			{
				Console.Clear();
				Console.WriteLine("The bus is empty and no passengers have boarded yet!" +
					"\nGo back to the menu and add passengers!\n" +
					"Press any key to return to the menu..");
				Console.ReadKey();
				return;
			}
			Console.Clear();
			Console.WriteLine("The age of all the passengers on the bus!");

			foreach (int x in passengers)
			{
				if (x == 0) // så inga tomma platser skrivs ut
                {
					break;
                }
			    Console.WriteLine(x);
			}
			Console.WriteLine("\nPress any key to return to the menu..");
			Console.ReadKey();
	    }

		// Metod för att räkna och skriva ut medelåldern med decimaler på bussen

		public void calc_average_age()

		{
			Console.Clear();
			double avarageAge = 0; // Deklarerar variabeln utanför loopen så man kommer åt den i och efter loopen

            for (int x =0; x < currentPassengers; x++)
            {
				avarageAge += passengers[x]; // += samma som (x = x + y)
			}
			double avarageAge2 = avarageAge / currentPassengers;

			Console.WriteLine($"The average age on the bus is:{avarageAge2}" + 
				"\nPress any key to return to the menu..");
			Console.ReadKey();
		}
		
		// Metod för att räkna och skriver ut den totala åldern på bussen

		public void calc_total_age()
		{
			Console.Clear();
			int totalAge = 0;

			for (int x = 0; x < currentPassengers; x++)
			{
				totalAge += passengers[x]; // += samma som (x = x + y)
			}
			int totalAge2 = totalAge;

			Console.WriteLine($"The total age on the bus is:{totalAge2}" + 
				"\nPress any key to return to the menu..");
			Console.ReadKey();
		}

		// Metod för att räkna och skriva ut den äldsta passageraren på bussen

		public void max_age()
		{
			Console.Clear();
			int maxAge = 0;

			for (int x = 0; x < currentPassengers; x++)
			{
				if(passengers[x] > maxAge) // Om vektorns värde är större än 0
                {
					maxAge = passengers[x]; // maxAge får indexpositionens värde och för varje varv sparas det största värdet i maxAge
                }
			}
			Console.WriteLine($"The oldest person on the bus is {maxAge} years old"+
				"\nPress any key to return to the menu..");
			Console.ReadKey();
		}
		
		// Metod för sortering av bussen, där äldst skrivs först och yngst sist 

		public void sort_buss()
		{
			Console.Clear();
			Console.WriteLine("Passengers sorted from oldest to youngest!");
			int temp; // variabeln för att kunna "mellanlanda" ett värde här för sorteringen

			for (int x = 0; x < passengers.Length; x++) // Håller koll på vart i vektorn vi befinner oss
			{
				for (int y = 0; y < passengers.Length; y++) // Jämför talen och sparar värdet i rätt ordning
				{
					if (passengers[x] > passengers[y]) // är x i vektorn större än y
					{
						temp = passengers[x]; // värdet på x sparas i temp
						passengers[x] = passengers[y]; // här byter man alltså plats på värdet i vektorn
						passengers[y] = temp; // här får y värdet från temp
					}
				}
			}

			// Skriver ut sorteringen och om platsen är tom ( värde 0 i vektorn ) bryts loopen och inga fler platser skrivs ut

			for (int i = 0; i < currentPassengers; i++)
			{
				if(passengers[i] <= 0)
                {
					break;
                }
				Console.WriteLine($"{passengers[i]}");
			}
			Console.WriteLine("\nPress any key to return to the menu..");
			Console.ReadKey();
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			var minbuss = new BussenSH2();
			minbuss.Run();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}

}