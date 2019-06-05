using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour
{
    public Text scoreText;

    public Image colorImage;

    public string SaveDataKey;

    int score = 0;

    public Color[] colors;

    ScoreContainerSaveData saveData = new ScoreContainerSaveData();

    public void ButtonIncreaseScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ButtonDecreaseScore()
    {
        score -= 1;
        scoreText.text = score.ToString();
    }

    public void ButtonChangeColor()
    {
        int randomId = Random.Range(0, colors.Length);
        colorImage.color = colors[randomId];
    }
    

    public void ButtonSaveGame()
    {
        saveData.color = SaveSystemConverter.ConvertColortoFloat4(colorImage.color);
        saveData.score = score;
        SaveSytem.SaveGame(saveData, SaveDataKey);

    }

    public void ButtonLoadGame()
    {
        saveData = SaveSytem.GetSaveData(SaveDataKey) as ScoreContainerSaveData;
        score = saveData.score;
        scoreText.text = score.ToString();
        colorImage.color = SaveSystemConverter.ConvertFloat4ToColor(saveData.color);
    }
}
