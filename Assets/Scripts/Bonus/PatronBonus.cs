using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronBonus : MonoBehaviour
{
    public ParticleSystem patronBonus;
    private GameObject _gun;
    private GameObject _audioManager;
    private AudioSource _audioSource;
    private void Start()
    {
        _gun = GameObject.FindGameObjectWithTag("PlayerGUn");
        _audioManager = GameObject.FindGameObjectWithTag("Shild");
        _audioSource = _audioManager.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
           _gun.GetComponent<GunController>().PatronBonus();
            Instantiate(patronBonus, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(_audioSource.clip);
            Destroy(gameObject);
        }
    }
}
