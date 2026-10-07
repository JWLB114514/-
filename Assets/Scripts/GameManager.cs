using UnityEngine;

public class GameManager : MonoBehaviour
{
    //单例，给其他脚本访问 GameManager.Instance
    public static GameManager Instance;

    public enum GameState
    {
        Playing,
        Paused,
        GameOver
    }

    public GameState currentState = GameState.Playing;
    public float surviveTime = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (currentState == GameState.Playing)
        {
            surviveTime += Time.deltaTime;
        }
    }
}
