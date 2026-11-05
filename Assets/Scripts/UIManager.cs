using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private UIDocument uiDocument;

    private Label _scoreLabel;
    private Label _timeLabel;
    private RadioButtonGroup _timerRadio;
    private Button _startButton;

    private int score;
    private int timeRemaining = 60;

    void Start()
    {
    }

    void Update()
    {
    }
}
