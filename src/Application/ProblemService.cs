using Core.Entities;
using Infrastructure;

namespace Application;

public class ProblemService
{
	private readonly FileProblemRepository _repository;

	public ProblemService(FileProblemRepository repository)
	{
		_repository = repository;
	}

	public IEnumerable<ProblemMetadata> GetAllProblems()
	{
		return _repository.GetAllProblems();
	}
}
