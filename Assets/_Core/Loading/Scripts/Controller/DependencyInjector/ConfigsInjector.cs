using Sablo.Core;
using UnityEngine;

public class ConfigsInjector : MonoBehaviour
{
    [SerializeField] private AppConfig _appConfigs;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private ViewConfig _viewConfig;

    private void Awake()
    {
        InjectConfigs();
    }

    public void InjectConfigs()
    {
        Configs.AppConfig = _appConfigs;
        Configs.GameConfig = _gameConfig;
        Configs.ViewConfig = _viewConfig;
    }
}
