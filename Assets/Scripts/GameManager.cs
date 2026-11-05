using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float speed;
    public bool gameOver;
    public bool startGame { get; set; }

    void Start()
    {
    }

    void Update()
    {
    }
}
