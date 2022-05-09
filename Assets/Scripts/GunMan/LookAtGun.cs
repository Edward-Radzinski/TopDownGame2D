using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtGun : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Bullet;
    public Transform Spawn;

    private AudioSource _AS;
    private float _time = 3;
    [SerializeField] private float _timeRate;
    private void Start()
    {
        _AS = GetComponent<AudioSource>();
        _AS.volume = PlayerPrefs.GetFloat("effectsVolume");
    }
    private void Update()
    {
        //transform.LookAt(PlayerController.instance.transform.position, Vector3.right);
        LookAtMouse();
        _time -= Time.deltaTime;
        if(_time <= 0)
        {
            _AS.PlayOneShot(_AS.clip);
            Shoot();
            _time = _timeRate;
        }

    }
    private void LookAtMouse()
    {
        var playerPosition = PlayerController.instance.transform.position;
        var angle = Vector2.Angle(Vector2.right, playerPosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < playerPosition.y ? angle : -angle);
    }
    private void Shoot()
    {
        Instantiate(Bullet, Spawn.position, transform.rotation);
    }
}
