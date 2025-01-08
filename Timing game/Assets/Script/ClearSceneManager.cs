using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneManager : MonoBehaviour
{
    public GameObject nextLevelButton;  // 次の難易度ボタン
    public string difficulty;           // 現在の難易度 (Easy, Normal, Hard)

    void Start()
    {

        difficulty = GameSettings.Instance.Difficulty;
        
        // 難易度に応じてボタンを表示/非表示にする
        if (difficulty == "Hard")
        {
            nextLevelButton.SetActive(false);  // ハードの場合、次の難易度ボタンを非表示
        }
        else
        {
            nextLevelButton.SetActive(true);  // イージーとノーマルはボタンを表示
        }
    }

    // タイトルに戻るボタン
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // 次の難易度に進むボタン
    public void GoToNextLevel()
    {
        if (difficulty == "Easy")
        {
            // イージーからノーマルへ進む
            GameSettings.Instance.Difficulty = "Normal";
            SceneManager.LoadScene("GameScene");
        }
        else if (difficulty == "Normal")
        {
            // ノーマルからハードへ進む
            GameSettings.Instance.Difficulty = "Hard";
            SceneManager.LoadScene("GameScene");
        }
    }
}
