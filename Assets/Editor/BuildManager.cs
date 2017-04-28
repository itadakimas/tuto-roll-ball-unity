using System;
using UnityEditor;
using UnityEditor.iOS.Xcode;

public class BuildManager
{
    private static BuildPlayerOptions PlayerOptionsFactory(BuildTarget target)
    {
        BuildPlayerOptions options = new BuildPlayerOptions();

        string[] scenes = {"Assets/Scenes/RollBallGame.unity"};
        string buildsDirectory = "Builds/";

        options.scenes = scenes;
        options.options = BuildOptions.None;
        options.target = target;
        options.locationPathName = buildsDirectory + target;
        return options;
    }

    private static void ConfigureXcodeProject(string cwd)
    {
        PBXProject project = new PBXProject();
        string xCodeDir = cwd + "/Builds/iOS";
        string pbxprojPath = xCodeDir + "/Unity-iPhone.xcodeproj/project.pbxproj";
        string exportPlistSourcePath = cwd + "/Export.plist";
        string exportPlistDestinationPath = xCodeDir + "/Export.plist";

        project.ReadFromFile(pbxprojPath);
        project.AddFile(exportPlistSourcePath, exportPlistDestinationPath);
        project.WriteToFile(pbxprojPath);
    }

    private static void Fail(string message)
    {
        Console.Error.Write(message);
        EditorApplication.Exit(1);
    }

    public static void BuildIOS()
    {
        string cwd;
        string[] args = Environment.GetCommandLineArgs();

        if (args.Length != 1)
        {
            Fail("invalid number of argument passed to iOS project build method");
        }
        BuildPipeline.BuildPlayer(PlayerOptionsFactory(BuildTarget.iOS));
        cwd = args[0];
        ConfigureXcodeProject(cwd);
    }
}
