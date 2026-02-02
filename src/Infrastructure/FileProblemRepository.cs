using Core.Entities;
using System.Text.Json;

namespace Infrastructure;

public class FileProblemRepository
{
    private readonly string _directoryPath;

    public FileProblemRepository(string directoryPath)
    {
        _directoryPath = directoryPath;
    }

    public IEnumerable<ProblemMetadata> GetAllProblems()
    {
        if (!Directory.Exists(_directoryPath))
        {
            yield break;
        }

        var metaFiles = Directory.GetFiles(_directoryPath, "*.meta.json", SearchOption.AllDirectories);

        foreach (var metaFile in metaFiles)
        {
            var json = File.ReadAllText(metaFile);
            var metadata = JsonSerializer.Deserialize<ProblemMetadata>(json);

            if (metadata is not null)
            {
                var codePath = Path.ChangeExtension(metaFile, ".cs");

                metadata.FilePath = File.Exists(codePath) ? codePath : string.Empty;

                yield return metadata;
            }
        }
    }
}
