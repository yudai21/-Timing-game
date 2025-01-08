using UnityEngine;
public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public string Difficulty;  // 現在の難易度

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetDifficulty(string difficulty)
    {
        Difficulty = difficulty;
    }
}
