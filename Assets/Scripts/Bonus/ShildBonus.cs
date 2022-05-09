using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildBonus : MonoBehaviour
{
    public ParticleSystem shildBonus;
    private GameObject _audioManager;
    private AudioSource _audioSource;
    [SerializeField] private int _value = 15;
    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Shild");
        _audioSource = _audioManager.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController.instance.ShildBonus();
            Instantiate(shildBonus, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(_audioSource.clip);
            Destroy(gameObject);
        }
    }
}
