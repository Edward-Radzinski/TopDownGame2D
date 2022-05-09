using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public Text ScoreText;
    [SerializeField] private Image _img;
    private void Awake()
    {
        _img.color = new Color32(0, 0, 0, (byte)((1 - PlayerPrefs.GetFloat("Brightness")) * 100));
    }
    private void Start()
    {
        score = 0;
        ScoreText.text = "0";
    }
    private void Update()
    {
        ScoreText.text = score.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
