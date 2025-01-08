using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void OnEasyButtonClicked()
    {
        GameSettings.Instance.SetDifficulty("Easy");
        SceneManager.LoadScene("GameScene");
    }

    public void OnNormalButtonClicked()
    {
        GameSettings.Instance.SetDifficulty("Normal");
        SceneManager.LoadScene("GameScene");
    }

    public void OnHardButtonClicked()
    {
        GameSettings.Instance.SetDifficulty("Hard");
        SceneManager.LoadScene("GameScene");
    }
}
