using Nuke.Common;
using Nuke.Common.Tools.GitVersion;
using Serilog;

class Build : NukeBuild
{
	[GitVersion]
	GitVersion GitVersion;

	Target ShowVersion => _ => _.Executes(() => { Log.Information("Current Version: " + GitVersion.NuGetVersion); });

	public static int Main() => Execute<Build>(x => x.ShowVersion);
}
