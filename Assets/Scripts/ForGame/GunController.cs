using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Bullet;
    public GameObject Gun;
    public Transform Spawn;

    [Header("Characteristics")]
    [SerializeField] private float _timeRate;
    [SerializeField] private float _offset;
    
    private Animation _anim;
    private AudioSource _AS;
    private float _timeFire = 0;
    private float _tempRate;
    
    private void Start()
    {
        _tempRate = _timeRate;
        _AS = GetComponent<AudioSource>();
        _anim = GetComponent<Animation>(); 
    }
    private void Update()
    {
        LookAtMouse();
        Shooting();
    }
    private void Shooting()
    {
        _timeFire -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && _timeFire <= 0)
        {
            _AS.PlayOneShot(_AS.clip);
            _anim.Play();
            _timeFire = _timeRate;
            Instantiate(Bullet, Spawn.position, Gun.transform.rotation);
        }
    }
    private void LookAtMouse()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);
    }
    public void PatronBonus()
    {
        _timeRate = 0.02f; 
        StopCoroutine(PatronBonusCorutine());
        StartCoroutine(PatronBonusCorutine());
    }
    private IEnumerator PatronBonusCorutine()
    {
        yield return new WaitForSeconds(5);
        _timeRate = _tempRate;
    }
}
