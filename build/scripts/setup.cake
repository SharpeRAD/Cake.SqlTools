///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(context =>
{
    // Executed BEFORE the first task.
    Information("Building version {0} of {1}.", semVersion, appName);
    Information("Target: {0}.", target);
});



Teardown(context =>
{
    // Executed AFTER the last task.
    Information("Finished building version {0} of {1}.", semVersion, appName);
});
