using System;
using UnityEditor;
using UnityEditor.iOS.Xcode;

public class BuildManager
{
    private static BuildPlayerOptions PlayerOptionsFactory(BuildTarget target)
    {
        BuildPlayerOptions options = new BuildPlayerOptions();

        string[] scenes = {"Assets/_Scenes/RollBallGame.unity"};
        string buildsDirectory = "Builds/";

        options.scenes = scenes;
        options.options = BuildOptions.None;
        options.target = target;
        options.locationPathName = buildsDirectory + target;
        return options;
    }

  /*  private static void ConfigureXcodeProject(string cwd)
    {
        PBXProject project = new PBXProject();
        string xCodeDir = cwd + "/Builds/iOS";
        string pbxprojPath = xCodeDir + "/Unity-iPhone.xcodeproj/project.pbxproj";
        string exportPlistPath = cwd + "/_iOS/Xcode/Export.plist";

        project.ReadFromFile(pbxprojPath);
        project.AddFile(exportPlistPath, exportPlistPath);
        project.WriteToFile(pbxprojPath);
    }*/

    private static void Fail(string message)
    {
        Console.Error.Write(message);
        EditorApplication.Exit(1);
    }

    private static string GetArg(string name)
    {
        string[] args = Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == name && args.Length > i + 1)
            {
                return args[i + 1];
            }
        }
        return null;
    }

    public static void BuildIOS()
    {
        string cwd = GetArg("-cwd");

        if (cwd == null)
        {
            Fail("Missing -cwd option");
        }
        BuildPipeline.BuildPlayer(PlayerOptionsFactory(BuildTarget.iOS));
//        ConfigureXcodeProject(cwd);
    }
}
