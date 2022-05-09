using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    public ParticleSystem hitPref;

    [Header("Characteristics")]
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _damage = 5;

    private void Start()
    {
        _damage = PlayerPrefs.GetInt("enemyDamage");
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rb.velocity = transform.TransformVector(Vector2.right) * _speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().GetDamage(_damage);
        }
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamage(_damage);
        }
        Instantiate(hitPref, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
