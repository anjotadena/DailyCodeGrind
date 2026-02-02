namespace Core.Entities;

public class ProblemMetadata
{
    public required string Title { get; set; }
    public required string Url { get; set; }
    public required string Difficulty { get; set; }
    public DateTime SolvedAt { get; set; }
    public required string Description { get; set; }
    public required string Complexity { get; set; }
    public required string FilePath { get; set; } // Full path to .cs solution file

}
