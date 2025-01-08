using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AIMTileManager : MonoBehaviour
{
    public Button[] tiles;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private int targetCount = 1;
    private float gameTime = 30f; // デフォルトはEasy
    private int requiredScore = 10; // デフォルトはEasy

    private List<int> currentTargetIndices = new List<int>();
    private int score = 0;
    private float remainingTime;
    private bool isGameActive = true;

    void Awake()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            int index = i;
            tiles[i].onClick.AddListener(() => OnTileClicked(index));
        }
    }

    void Start()
    {
        // 難易度設定を適用
        string difficulty = GameSettings.Instance.Difficulty;

        if (difficulty == "Easy")
        {
            gameTime = 20f;
            requiredScore = 10;
        }
        else if (difficulty == "Normal")
        {
            gameTime = 20f;
            requiredScore = 30;
        }
        else if (difficulty == "Hard")
        {
            gameTime = 30f;
            requiredScore = 50; 
        }

        remainingTime = gameTime;
        UpdateScoreText();
        UpdateTimerText();
        SetNewTargets();
    }

    void Update()
    {
        if (isGameActive)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                CheckGameResult();
            }
        }
    }

    public void OnTileClicked(int index)
    {
        if (!isGameActive) return;

        if (currentTargetIndices.Contains(index))
        {
            tiles[index].GetComponent<Image>().color = Color.green;
            score++;
            UpdateScoreText();
            currentTargetIndices.Remove(index);

            if (currentTargetIndices.Count == 0)
            {
                SetNewTargets();
            }
        }
    }

    private void SetNewTargets()
    {
        foreach (Button tile in tiles)
        {
            tile.GetComponent<Image>().color = Color.green;
        }

        currentTargetIndices.Clear();
        while (currentTargetIndices.Count < targetCount)
        {
            int randomIndex = Random.Range(0, tiles.Length);
            if (!currentTargetIndices.Contains(randomIndex))
            {
                currentTargetIndices.Add(randomIndex);
                tiles[randomIndex].GetComponent<Image>().color = Color.red;
            }
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score} / {requiredScore}";
    }

    private void UpdateTimerText()
    {
        timerText.text = $"Time: {Mathf.Ceil(remainingTime)}";
    }

    private void CheckGameResult()
    {
        isGameActive = false;

        foreach (Button tile in tiles)
        {
            tile.interactable = false;
        }

        if (score >= requiredScore)
        {
            // クリア条件を満たした場合はクリアシーンへ
            SceneManager.LoadScene("GameClearScene");
        }
        else
        {
            // ゲームオーバー条件を満たさなかった場合はゲームオーバーシーンに遷移
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
