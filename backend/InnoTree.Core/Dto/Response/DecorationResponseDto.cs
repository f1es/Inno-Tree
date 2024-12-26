namespace InnoTree.Core.Dto.Response;

public class DecorationResponseDto
{
	public Guid DecorationId { get; set; }
	public string Author { get; set; }
	public string Message {  get; set; }
	public string Type { get; set; }
	public int X {  get; set; }
	public int Y { get; set; }
}
