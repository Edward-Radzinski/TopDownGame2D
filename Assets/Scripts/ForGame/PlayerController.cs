using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    [Header("Characteristics")]
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    
    [Header("Bonus")]
    public GameObject Shild;
    
    [Header("UI")]
    public TextMeshProUGUI _tmp;
    private Rigidbody2D _rb;
    private Animator _anim;
    
    private float hMove;
    private float vMove;
    private bool shild = false;
    
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance == this)
            Destroy(gameObject);
    }
    private void Start()
    {
        _speed = PlayerPrefs.GetFloat("playerSpeed");
        _anim = GetComponent<Animator>();
        _tmp.text = _health.ToString();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        hMove = Input.GetAxis("Horizontal") * _speed;
        vMove = Input.GetAxis("Vertical") * _speed;
        if (hMove != 0 || vMove != 0) _anim.Play("PlayerWalk"); 
        else if(hMove == 0 && vMove == 0) _anim.Play("PlayerIdle"); 
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(hMove, vMove);
    }
    public void GetDamage(int damage)
    {
        if (shild) return;
        _health -= damage;
        if (_health <= 0)
        {
            _tmp.text = "0";
            Destroy(gameObject);
        }
        _tmp.text = _health.ToString();
    }
    public void GetHealth(int health)
    {
        if (_health + health <= 100)
            _health += health;
        else
            _health = 100;
        _tmp.text = _health.ToString();
    }
    public void ShildBonus()
    {
        Shild.SetActive(true);
        shild = true;
        StopCoroutine(ShildBonusCorutina());
        StartCoroutine(ShildBonusCorutina());
    }
    private IEnumerator ShildBonusCorutina()
    {
        yield return new WaitForSeconds(3);
        shild = false;
        Shild.SetActive(false);
    }
}
