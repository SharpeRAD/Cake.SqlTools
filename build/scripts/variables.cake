//////////////////////////////////////////////////////////////////////
// VARIABLES
//////////////////////////////////////////////////////////////////////

// Get whether or not this is a local build.
var local = BuildSystem.IsLocalBuild;
var isRunningOnAppVeyor = AppVeyor.IsRunningOnAppVeyor;
var isRunningOnTFS = (EnvironmentVariable("TF_BUILD") == "True");
var isPullRequest = AppVeyor.Environment.PullRequest.IsPullRequest;

// Parse release notes.
var releaseNotes = ParseReleaseNotes("./ReleaseNotes.md");
var copyright = "Phillip Sharpe";

// Get version.
var buildNumber = AppVeyor.Environment.Build.Number;
var version = releaseNotes.Version.ToString();
var semVersion = local ? version : (version + string.Concat("-build-", buildNumber));

// Define directories.
var buildResultDir = new DirectoryPath("./build/results").MakeAbsolute(Context.Environment);;
var testResultsDir = buildResultDir.Combine("tests");
var loggerResultsDir = buildResultDir.Combine("logger");
var nugetDir = buildResultDir.Combine("nuget");
var deployDir = buildResultDir.Combine("deploy");
var binDir = buildResultDir.Combine("bin");

// Project Locations
var solution = "./src/" + appName + ".sln";

var packageFileName = nugetDir.CombineWithFilePath($"Cake.SqlTools.{version}.nupkg");

