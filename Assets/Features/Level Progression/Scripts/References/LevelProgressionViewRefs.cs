using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionViewRefs : MonoBehaviour
{
    public Image BatteryFillImage;
    [HideInInspector]
    public float _fillValue = 0;
    
    public Button OkayButton;
    [Header("Views")]
    public GameObject CompletionScreen;
    public GameObject InGameScreen;
}
