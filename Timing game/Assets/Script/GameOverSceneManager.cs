using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    // リスタートボタンを押したときの処理
    public void RestartGame()
    {
        // ゲームシーンを再読み込みしてリスタート
        SceneManager.LoadScene("GameScene");
    }

    // タイトルに戻るボタンを押したときの処理
    public void GoToMainMenu()
    {
        // タイトルシーンに遷移
        SceneManager.LoadScene("TitleScene");
    }
}
