using System;
namespace FinalProject.Models
{
	public class Response
	{
		public int statusCode { get; set; }
		public string statusDescription { get; set; }
		public List<Musics?> Musics { get; set; }
	}
}

