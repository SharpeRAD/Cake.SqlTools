///////////////////////////////////////////////////////////////////////////////
// PUBLISH
///////////////////////////////////////////////////////////////////////////////

Task("Publish-Local")
    .IsDependentOn("Build")
    .WithCriteria(() => local)
    .WithCriteria(() => !isPullRequest)
    .Does(() =>
{
    var packageDir = Context.FileSystem.GetDirectory(@"C:/Projects/Packages/");

    if (packageDir.Exists)
    {      
        var files = packageDir.GetFiles("Cake.SqlTools.*", SearchScope.Current);

        foreach (IFile file in files)
        {
            DeleteFile(file.Path);
        }
        
        // Copy
        CopyFileToDirectory(packageFileName, packageDir.Path);
    }
});



Task("Publish-Nuget")
    .IsDependentOn("Build")
    .WithCriteria(() => isRunningOnAppVeyor || isRunningOnTFS || (target == "Skip-Restore") )
    .WithCriteria(() => !isPullRequest)
    .Does(() =>
{
    // Check the API key
    var apiKey = EnvironmentVariable("NUGET_API_KEY");

    if (string.IsNullOrEmpty(apiKey))    
        throw new InvalidOperationException("Could not resolve nuget API key.");    
  
    NuGetPush(packageFileName, new NuGetPushSettings
    {
        Source = "https://www.nuget.org/api/v2/package",
        ApiKey = apiKey
    });
});