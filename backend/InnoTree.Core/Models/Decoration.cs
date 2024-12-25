namespace InnoTree.Core.Models;

public class Decoration
{
	public Guid Id { get; set; }
	public string? Author { get; set; }
	public string? Message { get; set; }
	public string? Type { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
}
