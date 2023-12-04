//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Package")
    .IsDependentOn("Build")
    .IsDependentOn("Publish-Local");

Task("Publish")
	.IsDependentOn("Package")
    .IsDependentOn("Publish-Nuget");



Task("AppVeyor")
    .IsDependentOn("Publish")
    .IsDependentOn("Update-AppVeyor-Build-Number")
    .IsDependentOn("Upload-AppVeyor-Artifacts")
    .IsDependentOn("Slack");
	


Task("Skip-Test")
    .IsDependentOn("Build");

Task("Skip-Restore")
    .IsDependentOn("Build");



Task("Default")
    .IsDependentOn("Publish");
