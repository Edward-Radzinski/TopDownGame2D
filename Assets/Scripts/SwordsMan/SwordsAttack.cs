using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    //private void LookAtPlayer()
    //{
    //    var playerPosition = PlayerController.instance.transform.position;
    //    var angle = Vector2.Angle(Vector2.right, playerPosition - transform.position);
    //    transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < playerPosition.y ? angle : -angle);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
            collision.gameObject.GetComponent<PlayerController>().GetDamage(_damage);
    }
}
