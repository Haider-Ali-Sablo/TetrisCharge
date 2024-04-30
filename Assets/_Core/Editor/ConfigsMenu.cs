using UnityEngine;
using UnityEditor;

namespace Sablo.Core
{
    public class ConfigsMenu: MonoBehaviour
    {
        [MenuItem("Sablo/Configs/AppConfig")]
        private static void ShowAppConfig()
        {
            var appConfig = Resources.Load<AppConfig>(Constants.ConfigPath.AppConfigPath);
            if (appConfig != null)
            {
                Selection.activeObject = appConfig;
                return;
            }
            Debug.LogError("AppConfig asset not found!");
        }
        
        [MenuItem("Sablo/Configs/GameConfig")]
        private static void ShowGameConfig()
        {
            var appConfig = Resources.Load<GameConfig>(Constants.ConfigPath.GameConfigsPath);
            if (appConfig != null)
            {
                Selection.activeObject = appConfig;
                return;
            }
            Debug.LogError("GameConfig asset not found!");
        }
        
        [MenuItem("Sablo/Configs/ViewConfig")]
        private static void ShowViewConfig()
        {
            var appConfig = Resources.Load<ViewConfig>(Constants.ConfigPath.ViewConfigsPath);
            if (appConfig != null)
            {
                Selection.activeObject = appConfig;
                return;
            }
            Debug.LogError("ViewConfig asset not found!");
        }
    }
}