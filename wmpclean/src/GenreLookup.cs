using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace wmpclean
{
	class GenreLookup
	{
		/// <summary>
		/// Static Constructor
		/// </summary>
		static GenreLookup()
		{
			// GENRE MAP
			//
			// SUB-GENRE --> HIGH-LEVEL GENRE

			s_genres = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			// GENRE-MAPPINGS.DAT
			if (File.Exists(Path.Combine(Application.StartupPath, "genre-mappings.dat")))
				LoadFromMappingFile(Path.Combine(Application.StartupPath, "genre-mappings.dat"));

			// GENRE-MAPPINGS-DEFAULT.DAT
			else if (File.Exists(Path.Combine(Application.StartupPath, "genre-mappings-default.dat")))
				LoadFromMappingFile(Path.Combine(Application.StartupPath, "genre-mappings-default.dat"));

			else
			{
				//
				// (I can't believe I'm actually typing all these in one at a time ... seriously.)
				//

				// ALTERNATIVE (11)
				s_genres.Add("Alternative", "Alternative");
				s_genres.Add("Alt Metal", "Alternative");
				s_genres.Add("Alternative Rock", "Alternative");
				s_genres.Add("Funk Metal", "Alternative");
				s_genres.Add("Alternative Dance", "Alternative");
				s_genres.Add("Grunge", "Alternative");
				s_genres.Add("Alternative Pop", "Alternative");
				s_genres.Add("Alternative Singer-Songwriter", "Alternative");
				s_genres.Add("Alternative Christian", "Alternative");
				s_genres.Add("Industrial", "Alternative");
				s_genres.Add("Goth", "Alternative");

				// PUNK (8)
				s_genres.Add("Punk", "Punk");
				s_genres.Add("Classic Punk", "Punk");
				s_genres.Add("Classic Pop Punk", "Punk");
				s_genres.Add("Hard Punk", "Punk");
				s_genres.Add("Pop Punk", "Punk");
				s_genres.Add("Other Punk", "Punk");
				s_genres.Add("Emo", "Punk");
				s_genres.Add("Hardcore", "Punk");

				// INDIE ROCK (11)
				s_genres.Add("Indie Rock", "Indie Rock");
				s_genres.Add("Alternative Folk", "Indie Rock");
				s_genres.Add("Ska Revival", "Indie Rock");
				s_genres.Add("Post-Punk", "Indie Rock");
				//s_genres.Add("Indie Rock",					"Indie Rock");	// Duplicated in QMP
				s_genres.Add("Indie Pop", "Indie Rock");
				s_genres.Add("Power Pop", "Indie Rock");
				s_genres.Add("Dream Pop", "Indie Rock");
				s_genres.Add("Post-Modern Electronic Pop", "Indie Rock");
				s_genres.Add("Post-Modern Art Rock", "Indie Rock");
				s_genres.Add("Art & Experimental Rock", "Indie Rock");

				// METAL (7)
				s_genres.Add("Metal", "Metal");
				s_genres.Add("Extreme Metal", "Metal");
				s_genres.Add("Thrash & Speed Metal", "Metal");
				s_genres.Add("Progressive Metal", "Metal");
				s_genres.Add("Gothic Metal", "Metal");
				s_genres.Add("Doom Metal", "Metal");
				s_genres.Add("Heavy Metal", "Metal");

				// ROCK (31)
				s_genres.Add("Rock", "Rock");
				s_genres.Add("Doo Wop", "Rock");
				s_genres.Add("Rockabilly", "Rock");
				s_genres.Add("Early Rock & Roll", "Rock");
				s_genres.Add("Psychedelic", "Rock");
				s_genres.Add("Early 60's Pop-Rock", "Rock");
				s_genres.Add("British Invasion", "Rock");
				s_genres.Add("Surf Rock", "Rock");
				s_genres.Add("Garage Rock", "Rock");
				s_genres.Add("Progressive Rock", "Rock");
				s_genres.Add("Classic Rock", "Rock");
				s_genres.Add("Blues, Boogie & Southern Rock", "Rock");
				s_genres.Add("Country Rock", "Rock");
				s_genres.Add("Classic Soft Rock", "Rock");
				s_genres.Add("Classic Pop-Rock", "Rock");
				s_genres.Add("Alternative Roots", "Rock");
				s_genres.Add("Asian Rock", "Rock");
				s_genres.Add("Christian Rock", "Rock");
				s_genres.Add("British Rock", "Rock");
				s_genres.Add("European Rock", "Rock");
				s_genres.Add("Folk Rock", "Rock");
				s_genres.Add("Pop Metal", "Rock");
				s_genres.Add("Hard Rock", "Rock");
				s_genres.Add("Japanese Rock", "Rock");
				s_genres.Add("Latin Rock", "Rock");
				s_genres.Add("Mainstream Rock", "Rock");
				s_genres.Add("Rock Singer-Songwriter", "Rock");
				s_genres.Add("Adult Alternative Rock", "Rock");
				s_genres.Add("Retro Rock Revival", "Rock");
				s_genres.Add("Instrumental Rock", "Rock");
				s_genres.Add("Jam Bands", "Rock");

				// POP (27)
				s_genres.Add("Pop", "Pop");
				s_genres.Add("African Pop", "Pop");
				s_genres.Add("Korean Pop", "Pop");
				s_genres.Add("Chinese Pop", "Pop");
				s_genres.Add("Southeast Asian Pop", "Pop");
				s_genres.Add("Central Asian Pop", "Pop");
				s_genres.Add("Indian Film Pop", "Pop");
				s_genres.Add("Other Indian Pop", "Pop");
				s_genres.Add("European Pop", "Pop");
				s_genres.Add("Japanese Pop", "Pop");
				s_genres.Add("Kayoukyoku & Enka", "Pop");
				s_genres.Add("Latin Pop", "Pop");
				s_genres.Add("Middle East Pop", "Pop");
				s_genres.Add("New Wave", "Pop");
				s_genres.Add("Bubblegum & Sunshine Pop", "Pop");
				s_genres.Add("Adult Alternative Pop", "Pop");
				s_genres.Add("Adult Contemporary", "Pop");
				s_genres.Add("Soft Rock", "Pop");
				s_genres.Add("Pop Vocal", "Pop");
				s_genres.Add("Ethnic Fusion Pop", "Pop");
				s_genres.Add("General Pop", "Pop");
				s_genres.Add("Teen Pop", "Pop");
				s_genres.Add("Singer-Songwriter", "Pop");
				s_genres.Add("Christian Pop", "Pop");
				s_genres.Add("Other Pop", "Pop");
				s_genres.Add("Karaoke", "Pop");
				s_genres.Add("World Pop Fusion", "Pop");

				// EASY LISTENING (9)
				s_genres.Add("Easy Listening", "Easy Listening");
				s_genres.Add("Pop Choral", "Easy Listening");
				s_genres.Add("Classic Pop Vocals", "Easy Listening");
				s_genres.Add("Show Tunes", "Easy Listening");
				s_genres.Add("Lounge", "Easy Listening");
				s_genres.Add("Other Easy Listening", "Easy Listening");
				s_genres.Add("Early Pop Vocals", "Easy Listening");
				s_genres.Add("Pops Dance", "Easy Listening");
				s_genres.Add("Nostalgia", "Easy Listening");

				// DANCE & HOUSE (7)
				s_genres.Add("Dance & House", "Dance & House");
				s_genres.Add("Club Dance", "Dance & House");
				s_genres.Add("Dance Pop", "Dance & House");
				s_genres.Add("Disco", "Dance & House");
				s_genres.Add("U.K. Garage", "Dance & House");
				s_genres.Add("House", "Dance & House");
				s_genres.Add("Progressive House", "Dance & House");

				// ELECTRONICA (13)
				s_genres.Add("Electronica", "Electronica");
				s_genres.Add("Acid Jazz", "Electronica");
				s_genres.Add("Downtempo", "Electronica");
				s_genres.Add("Neo-Lounge", "Electronica");
				s_genres.Add("Trip Hop", "Electronica");
				s_genres.Add("Ambient Electronica", "Electronica");
				s_genres.Add("Jungle/Drum 'n' Bass", "Electronica");
				s_genres.Add("Electronica Fusion", "Electronica");
				s_genres.Add("Electronica Mainstream", "Electronica");
				s_genres.Add("Techno", "Electronica");
				s_genres.Add("Intelligent (IDM)", "Electronica");
				s_genres.Add("Hardcore Techno", "Electronica");
				s_genres.Add("Trance", "Electronica");

				// R&B (10)
				s_genres.Add("R&B", "R&B");
				s_genres.Add("Funk", "R&B");
				s_genres.Add("Classic Motown", "R&B");
				s_genres.Add("Classic Soul/R&B", "R&B");
				s_genres.Add("Neo-Soul", "R&B");
				s_genres.Add("Contemporary R&B", "R&B");
				s_genres.Add("Urban Crossover", "R&B");
				s_genres.Add("New Jack Swing", "R&B");
				s_genres.Add("Pop Soul", "R&B");
				s_genres.Add("Quiet Storm", "R&B");

				// RAP (18)
				s_genres.Add("Rap", "Rap");
				s_genres.Add("Old School Rap/Hip-Hop", "Rap");
				s_genres.Add("Bass Music", "Rap");
				s_genres.Add("Southern Rap", "Rap");
				s_genres.Add("East Coast Rap", "Rap");
				s_genres.Add("Midwestern Rap", "Rap");
				s_genres.Add("West Coast", "Rap");
				s_genres.Add("Gangsta Rap", "Rap");
				s_genres.Add("Other Rap/Hip-Hop", "Rap");
				s_genres.Add("Mixtape", "Rap");
				s_genres.Add("Alternative Rap/Hip-Hop", "Rap");
				s_genres.Add("Christian Rap", "Rap");
				s_genres.Add("Reggaeton", "Rap");
				s_genres.Add("Latin Rap/Hip-Hop", "Rap");
				s_genres.Add("African Rap/Hip-Hop", "Rap");
				s_genres.Add("Japanese Rap/Hip-Hop", "Rap");
				s_genres.Add("Korean Rap/Hip-Hop", "Rap");
				s_genres.Add("Chinese Rap/Hip-Hop", "Rap");

				// JAZZ (16)
				s_genres.Add("Jazz", "Jazz");
				s_genres.Add("Avant Garde", "Jazz");
				s_genres.Add("Bebop", "Jazz");
				s_genres.Add("Hard Bop", "Jazz");
				s_genres.Add("Cool Jazz", "Jazz");
				s_genres.Add("Post-Bop", "Jazz");
				s_genres.Add("Modern Jazz", "Jazz");
				s_genres.Add("Big Band/Swing", "Jazz");
				s_genres.Add("Fusion", "Jazz");
				s_genres.Add("Contemporary Jazz", "Jazz");
				s_genres.Add("Soul Jazz", "Jazz");
				s_genres.Add("Early Jazz", "Jazz");
				s_genres.Add("Early Jazz Piano", "Jazz");
				s_genres.Add("Jazz Vocals", "Jazz");
				s_genres.Add("Latin & World Jazz", "Jazz");
				s_genres.Add("Smooth Jazz", "Jazz");

				// CLASSICAL (19)
				s_genres.Add("Classical", "Classical");
				s_genres.Add("Midieval & Chant", "Classical");
				s_genres.Add("Renaissance Era", "Classical");
				s_genres.Add("Baroque Era", "Classical");
				s_genres.Add("Classical Era", "Classical");
				s_genres.Add("Romantic Era", "Classical");
				s_genres.Add("Impressionist Era", "Classical");
				s_genres.Add("Modern Era", "Classical");
				s_genres.Add("Avant-Garde Classical", "Classical");
				s_genres.Add("Contemporary Era", "Classical");
				s_genres.Add("Minimalism", "Classical");
				s_genres.Add("Other Classical", "Classical");
				s_genres.Add("Ballet", "Classical");
				s_genres.Add("Classical Crossover", "Classical");
				s_genres.Add("Sacred Music/Mass", "Classical");
				s_genres.Add("Classical Solo Instrumental", "Classical");
				s_genres.Add("Classical Choral", "Classical");
				s_genres.Add("Classical Vocal", "Classical");
				s_genres.Add("Opera", "Classical");

				// BLUES (9)
				s_genres.Add("Blues", "Blues");
				s_genres.Add("Acoustic Blues", "Blues");
				s_genres.Add("Traditional Acoustic Blues", "Blues");
				s_genres.Add("Delta Blues", "Blues");
				s_genres.Add("Blues Vocals", "Blues");
				s_genres.Add("Other Blues", "Blues");
				s_genres.Add("Electric Blues", "Blues");
				s_genres.Add("Urban Blues", "Blues");
				s_genres.Add("Contemporary Blues", "Blues");

				// COUNTRY & FOLK (16)
				s_genres.Add("Country & Folk", "Country & Folk");
				s_genres.Add("Honky Tonk & Outlaw", "Country & Folk");
				s_genres.Add("Neo-Traditional Country", "Country & Folk");
				s_genres.Add("Traditional Country", "Country & Folk");
				s_genres.Add("Western Swing & Country Boogie", "Country & Folk");
				s_genres.Add("Americana", "Country & Folk");
				s_genres.Add("Alternative Country", "Country & Folk");
				s_genres.Add("Contemporary Country", "Country & Folk");
				s_genres.Add("Country Pop", "Country & Folk");
				s_genres.Add("Nashville Sound", "Country & Folk");
				s_genres.Add("Country", "Country & Folk");
				s_genres.Add("Bluegrass", "Country & Folk");
				s_genres.Add("Cajun, Creole & Zydeco", "Country & Folk");
				s_genres.Add("Old Timey", "Country & Folk");
				s_genres.Add("Contemporary U.S. Folk", "Country & Folk");
				s_genres.Add("Traditional U.S. Folk", "Country & Folk");

				// RELIGIOUS (8)
				s_genres.Add("Religious", "Religious");
				s_genres.Add("Indian Devotional", "Religious");
				s_genres.Add("Buddhist Devotional", "Religious");
				s_genres.Add("Christian Inspirational", "Religious");
				s_genres.Add("Gospel", "Religious");
				s_genres.Add("Hymns & Spirituals", "Religious");
				s_genres.Add("Islamic", "Religious");
				s_genres.Add("Jewish", "Religious");

				// LATIN (9)
				s_genres.Add("Latin", "Latin");
				s_genres.Add("Other Latin Traditional", "Latin");
				s_genres.Add("Mexican Traditional", "Latin");
				s_genres.Add("Latin Dance", "Latin");
				s_genres.Add("Latin Folk", "Latin");
				s_genres.Add("Central American", "Latin");
				s_genres.Add("Caribbean", "Latin");
				s_genres.Add("South American", "Latin");
				s_genres.Add("Brazilian Folk & Dance", "Latin");

				// REGGAE (4)
				s_genres.Add("Reggae", "Reggae");
				s_genres.Add("Dancehall Reggae", "Reggae");
				s_genres.Add("Roots Reggae", "Reggae");
				s_genres.Add("Classic Ska", "Reggae");

				// TRADITIONAL (33)
				s_genres.Add("Traditional", "Traditional");
				s_genres.Add("North African", "Traditional");
				s_genres.Add("West African", "Traditional");
				s_genres.Add("Southern African", "Traditional");
				s_genres.Add("Other African", "Traditional");
				s_genres.Add("Japanese Traditional", "Traditional");
				s_genres.Add("Korean Traditional", "Traditional");
				s_genres.Add("Chinese Traditional", "Traditional");
				s_genres.Add("Southeast Asian Traditional", "Traditional");
				s_genres.Add("Indonesian, Malaysian & Filipino", "Traditional");
				s_genres.Add("Central Asian Traditional", "Traditional");
				s_genres.Add("Other Asian", "Traditional");
				s_genres.Add("Indian Classical", "Traditional");
				s_genres.Add("Indian Folk", "Traditional");
				s_genres.Add("Pakistani", "Traditional");
				s_genres.Add("Himalayan", "Traditional");
				s_genres.Add("Other Indian Subcontinent", "Traditional");
				s_genres.Add("Celtic", "Traditional");
				s_genres.Add("Klezmer", "Traditional");
				s_genres.Add("Gypsy", "Traditional");
				s_genres.Add("Eastern European", "Traditional");
				s_genres.Add("Balkan States", "Traditional");
				s_genres.Add("Mediterranean", "Traditional");
				s_genres.Add("French", "Traditional");
				s_genres.Add("Northern European", "Traditional");
				s_genres.Add("Baltic States", "Traditional");
				s_genres.Add("Scandinavian", "Traditional");
				s_genres.Add("British Isles", "Traditional");
				s_genres.Add("Middle Eastern", "Traditional");
				s_genres.Add("Australasian", "Traditional");
				s_genres.Add("Pacific", "Traditional");
				s_genres.Add("North American", "Traditional");
				s_genres.Add("General World", "Traditional");

				// SOUNDTRACK (6)
				s_genres.Add("Soundtrack", "Soundtrack");
				s_genres.Add("Animation", "Soundtrack");
				s_genres.Add("Games", "Soundtrack");
				s_genres.Add("Original Film/TV Music", "Soundtrack");
				s_genres.Add("Stage Musicals", "Soundtrack");
				s_genres.Add("Sports Themes", "Soundtrack");

				// CHILDREN'S (3)
				s_genres.Add("Children's", "Children's");
				s_genres.Add("Children's Music", "Children's");
				s_genres.Add("Toddler & Baby Music", "Children's");

				// SPOKEN & AUDIO (4)
				s_genres.Add("Spoken & Audio", "Spoken & Audio");
				s_genres.Add("Comedy", "Spoken & Audio");
				s_genres.Add("Spoken Word", "Spoken & Audio");
				s_genres.Add("Audio Book", "Spoken & Audio");

				// HOLIDAY (3)
				s_genres.Add("Holiday", "Holiday");
				s_genres.Add("Other Holiday", "Holiday");
				s_genres.Add("Christmas", "Holiday");

				// NEW AGE (7)
				s_genres.Add("New Age", "New Age");
				s_genres.Add("Electronic & Space Music", "New Age");
				s_genres.Add("Meditative", "New Age");
				s_genres.Add("Environmental", "New Age");
				s_genres.Add("New Acoustic", "New Age");
				s_genres.Add("Popular New Age", "New Age");
				s_genres.Add("New Age World Music", "New Age");

				// OTHER (3)
				s_genres.Add("Other", "Other");
				s_genres.Add("Sound Effects", "Other");
				s_genres.Add("Data & Other", "Other");
			}
		}
		
		//---------------------------------------------------------------------
		// Member Functions

		/// <summary>
		/// Determines if the specified Genre exists in the list of CDDB-approved ones
		/// </summary>
		/// <param name="genre">Genre to be tested</param>
		public static bool IsValidGenre(string genre)
		{
			return s_genres.ContainsKey(genre);
		}

		/// <summary>
		/// Maps a specific genre into a top-level genre
		/// </summary>
		/// <param name="genre">Specific genre to be mapped</param>
		public static string MapGenre(string genre)
		{
			bool mapped;
			return MapGenre(genre, out mapped);
		}

		/// <summary>
		/// Maps a specific genre into a top-level genre
		/// </summary>
		/// <param name="genre">Specific genre to be mapped</param>
		/// <param name="mapped">TRUE if the genre was mapped</param>
		public static string MapGenre(string genre, out bool mapped)
		{
			mapped = false;
			if (!IsValidGenre(genre)) return genre;

			mapped = true;
			return s_genres[genre];
		}

		//-------------------------------------------------------------------
		// Private Member Functions

		/// <summary>
		/// Loads the collection from a genre-mappings file
		/// </summary>
		/// <param name="filename">Path to the genre-mappings file</param>
		private static void LoadFromMappingFile(string filename)
		{
			string line;
			s_genres.Clear();

			using (StreamReader rdr = new StreamReader(File.Open(filename, FileMode.Open, FileAccess.Read)))
			{
				line = rdr.ReadLine();
				while (line != null)
				{
					// not exactly bullet-proof here
					if ((!String.IsNullOrEmpty(line)) && (line.Contains("|")))
					{
						string[] parts = line.Split(new char[] { '|' });
						s_genres.Add(parts[0], parts[1]);
					}
					line = rdr.ReadLine();
				}
			}
		}

		//---------------------------------------------------------------------
		// Member Variables

		private static Dictionary<string, string> s_genres;	// Genre collection
	}
}
