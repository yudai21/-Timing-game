using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // シングルトンパターンで管理

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public static Difficulty SelectedDifficulty { get; private set; } = Difficulty.Normal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン遷移でもオブジェクトを保持
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SetDifficulty(Difficulty difficulty)
    {
        SelectedDifficulty = difficulty;
        Debug.Log("Selected Difficulty: " + difficulty);
    }
}
