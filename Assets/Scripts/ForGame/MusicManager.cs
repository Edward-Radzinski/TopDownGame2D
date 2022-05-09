using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource[] _asArray;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] private List<AudioClip> tempAudioList;
    private AudioSource _as;
    private void Start()
    {
        tempAudioList = new List<AudioClip>(audioClips);
        _as = GetComponent<AudioSource>();
        _as.volume = PlayerPrefs.GetFloat("musicVolume");
        for (int i = 0; i < _asArray.Length; i++)
        {
            _asArray[i].volume = PlayerPrefs.GetFloat("effectsVolume");
        }
        var rand = Random.Range(0, tempAudioList.Count);
        _as.PlayOneShot(tempAudioList[rand]);
        tempAudioList.RemoveAt(rand);
    }
    private void Update()
    {
        var rand = Random.Range(0, tempAudioList.Count);
        ChangeAudio(rand);
    }
    private void ChangeAudio(int rand)
    {
        if(tempAudioList.Count == 0)
            tempAudioList = new List<AudioClip>(audioClips);
        if (!_as.isPlaying)
        {
            _as.PlayOneShot(tempAudioList[rand]);
            tempAudioList.RemoveAt(rand);
        }

    }
}
