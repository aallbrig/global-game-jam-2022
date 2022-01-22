using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;

namespace Editor
{
    // Disable mobile warning on webgl!
    // https://answers.unity.com/questions/1339261/unity-webgl-disable-mobile-warning.html
    public static class PostBuildActions
    {
        # if UNITY_EDITOR
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string targetPath)
        {
            string path;
            if (File.Exists(Path.Combine(targetPath, "Build/UnityLoader.js")))
            {
                path = Path.Combine(targetPath, "Build/UnityLoader.js");
            }
            else
            {
                // In case files are hashed using MD5, just take the first .js file and hope it's the UnityLoader
                var files = Directory.GetFiles(Path.Combine(targetPath, "Build/"), "*.js");
                path = files.First();
            }
            var text = File.ReadAllText(path);
            text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
            File.WriteAllText(path, text);
        }
        #endif
    }
}