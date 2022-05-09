using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    private AudioSource _as;
    private void Awake()
    {
        _as = GetComponent<AudioSource>();
        _as.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Update()
    {
        _as.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    public void OffOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
