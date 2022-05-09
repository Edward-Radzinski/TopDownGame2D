using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    private enum Complexity
    {
        Easy,
        Medium,
        Hard
    }
    [Header("Complexity")]
    [SerializeField] private Complexity _complexity;
    [SerializeField] private Dropdown _dropdown;
    [SerializeField] private float _playerSpeed = 10;/////////////////////
    [SerializeField] private float _enemySpeed = 4;///////////////////////
    [SerializeField] private int _playerDamage = 5;///////////////////////
    [SerializeField] private int _enemyDamage = 5;////////////////////////
    [SerializeField] private float _timeRevival = 4;

    [Header("Display")]
    [SerializeField] private Image _img;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _brightness = 1;

    [Header("Music")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private float _musicVolume = 1;
    [SerializeField] private float _effectsVolume = 1;
    private void Start()
    {
        SaveGet();
    }
    private void SaveGet()
    {
        if (PlayerPrefs.HasKey("playerSpeed")) Get();
        else
        {
            _dropdown.value = 1;
            Save(_playerSpeed, _enemySpeed, _playerDamage, _enemyDamage, _timeRevival);
        }
        if (PlayerPrefs.HasKey("Brightness")) GetBrightness();
        else
        {
            _slider.value = 1;
            PlayerPrefs.SetFloat("Brightness", _brightness);
        }
        if (PlayerPrefs.HasKey("musicVolume")) GetMusic();
        else
        {
            _musicSlider.value = 1;
            _effectsSlider.value = 1;
            PlayerPrefs.SetFloat("musicVolume", _musicVolume);
            PlayerPrefs.SetFloat("effectsVolume", _effectsVolume);
        }
    }
    public void Easy()
    {
        _complexity = Complexity.Easy;
        _playerSpeed = 12;
        _enemySpeed = 3;
        _playerDamage = 8;
        _enemyDamage = 4;
        _timeRevival = 6;
        Save(_playerSpeed, _enemySpeed, _playerDamage, _enemyDamage, _timeRevival);
    }
    public void Medium()
    {
        _complexity = Complexity.Medium;
        _playerSpeed = 10;
        _enemySpeed = 4;
        _playerDamage = 5;
        _enemyDamage = 5;
        _timeRevival = 4;
        Save(_playerSpeed, _enemySpeed, _playerDamage, _enemyDamage, _timeRevival);
    }
    public void Hard()
    {
        _complexity = Complexity.Hard;
        _playerSpeed = 8;
        _enemySpeed = 5;
        _playerDamage = 4;
        _enemyDamage = 6;
        _timeRevival = 4;
        Save(_playerSpeed, _enemySpeed, _playerDamage, _enemyDamage, _timeRevival);
    }
    private void Save(float playerSpeed, float enemySpeed, int playerDamage, int enemyDamage, float timeRevival)
    {
        ///compaxity///
        PlayerPrefs.SetFloat("playerSpeed", playerSpeed);
        PlayerPrefs.SetFloat("enemySpeed", enemySpeed);
        PlayerPrefs.SetInt("playerDamage", playerDamage);
        PlayerPrefs.SetInt("enemyDamage", enemyDamage);
        PlayerPrefs.SetFloat("timeRevial", timeRevival);
    }
    private void Get()
    {
        ///compaxity///
        _dropdown.value = PlayerPrefs.GetInt("value");
        _playerSpeed = PlayerPrefs.GetFloat("playerSpeed");
        _enemySpeed = PlayerPrefs.GetFloat("enemySpeed");
        _playerDamage = PlayerPrefs.GetInt("playerDamage");
        _enemyDamage = PlayerPrefs.GetInt("enemyDamage");
        _timeRevival = PlayerPrefs.GetFloat("timeRevial");
    }
    private void GetBrightness()
    {
        ///brightness///
        _brightness = PlayerPrefs.GetFloat("Brightness");
        _slider.value = _brightness;
    }
    private void GetMusic()
    {
        _musicVolume = PlayerPrefs.GetFloat("musicVolume");
        _effectsVolume = PlayerPrefs.GetFloat("effectsVolume");
        _musicSlider.value = _musicVolume;
        _effectsSlider.value = _effectsVolume;
    }
   
    public void InputMenu(int value)
    {
        if (value == 0)
        {
            PlayerPrefs.SetInt("value", value);
            Easy();
        }
        else if (value == 1)
        {
            PlayerPrefs.SetInt("value", value);
            Medium();
        }
        else if (value == 2)
        {
            PlayerPrefs.SetInt("value", value);
            Hard();
        }
    }
    public void SliderBrightnessValue()
    {
        _brightness = _slider.value;
        PlayerPrefs.SetFloat("Brightness", _brightness);
        _img.color = new Color32(0, 0, 0, (byte)((1 - PlayerPrefs.GetFloat("Brightness")) * 100));
    }
    public void MusicSlider()
    {
        _musicVolume = _musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", _musicVolume);
    }
    public void EffectsSlider()
    {
        _effectsVolume = _effectsSlider.value;
        PlayerPrefs.SetFloat("effectsVolume", _effectsVolume);
    }
    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        SaveGet();
    }
}
