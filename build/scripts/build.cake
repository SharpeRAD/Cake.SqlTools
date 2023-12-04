///////////////////////////////////////////////////////////////////////////////
// BUILD
///////////////////////////////////////////////////////////////////////////////

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    Information("Building {0}", solution);

    // Create build settings
    var buildSettings = new DotNetMSBuildSettings
    {          
        MaxCpuCount = 3,
        Version = version,
        FileVersion = version,
		InformationalVersion = semVersion,
		PackageVersion = version
    };

    buildSettings.WithProperty("PackageOutputPath", nugetDir.FullPath);	

    // Add Logger
    buildSettings.AddFileLogger(new MSBuildFileLoggerSettings
    {
        LogFile = loggerResultsDir + "/build.txt",

        AppendToLogFile = false,
        ShowTimestamp = false,
        ShowCommandLine = false,
        ShowEventId = false,
        ForceNoAlign = true,
        HideItemAndPropertyList = true,

        Verbosity = DotNetVerbosity.Minimal
    });

    DotNetBuild(solution, new DotNetBuildSettings
    {
        Configuration = configuration,
        MSBuildSettings = buildSettings
    });
})
.OnError(exception =>
{
    List<SlackChatMessageAttachment> attachments = new List<SlackChatMessageAttachment>();



    // Get MsBuild Errors
    var path = loggerResultsDir + "/build.txt";

    if (FileExists(path))
    {
        IList<SlackChatMessageAttachment> lstAttachments = GetMsBuildAttachments(path, exception);

        CombineAttachments(attachments, lstAttachments);
    }



    // Resolve the webHook Url.
    var webHookUrl = EnvironmentVariable("SLACK_WEBHOOK_URL");

    if (string.IsNullOrEmpty(webHookUrl))
    {
        throw new InvalidOperationException("Could not resolve Slack webHook Url.");
    }



    // Post Message
    SlackChatMessageSettings settings = new SlackChatMessageSettings()
    {
        IncomingWebHookUrl = webHookUrl,
        UserName = "Cake",
        IconUrl = new System.Uri("https://cdn.jsdelivr.net/gh/cake-build/graphics/png/cake-small.png")
    };

    var title = "Build failed for " + appName + " v" + version;

    SlackChatMessageResult result = Slack.Chat.PostMessage("#code", title, attachments, settings);



    // Check Result
    if (result.Ok)
    {
        // Posted
        Information("Message was succcessfully sent to Slack.");
    }
    else
    {
        // Error
        Error("Failed to send message to Slack: {0}", result.Error);
    }

    throw exception;
});

