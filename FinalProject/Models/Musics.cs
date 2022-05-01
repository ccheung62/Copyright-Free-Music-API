using System;
namespace FinalProject.Models
{
	public class Musics
	{
		public int MusicsId { get; set; }
		public string Name { get; set; }
		public string Link { get; set; }
		public Artists Artists { get; set; }
		public Genres Genres { get; set; }
	}
}

