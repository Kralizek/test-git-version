#tool "nuget:?package=GitVersion.CommandLine"

Task("GetVersion")
    .Does(() => 
{
    var version = GitVersion();

    Information($"Current version: {version.FullSemVer}");

    if (BuildSystem.IsRunningOnTeamCity)
    {
        TeamCity.SetBuildNumber(version.FullSemVer);
    }
});

RunTarget("GetVersion");