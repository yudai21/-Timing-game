using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public void SetEasy()
    {
        GameManager.SetDifficulty(GameManager.Difficulty.Easy);
        LoadGameScene();
    }

    public void SetNormal()
    {
        GameManager.SetDifficulty(GameManager.Difficulty.Normal);
        LoadGameScene();
    }

    public void SetHard()
    {
        GameManager.SetDifficulty(GameManager.Difficulty.Hard);
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene"); // ゲームシーンに遷移
    }
}
