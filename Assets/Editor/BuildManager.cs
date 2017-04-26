using UnityEditor;

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

    public static void BuildIOS()
    {
        BuildPipeline.BuildPlayer(PlayerOptionsFactory(BuildTarget.iOS));
    }
}
