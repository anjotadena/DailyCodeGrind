using Infrastructure;

const string problemsRoot = "";

// Dependencies
var repository = new FileProblemRepository(problemsRoot);
var service = new Application.ProblemService(repository);
var ui = new ConsoleUI(service);



