using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMan : MonoBehaviour
{
    public GameObject Pivot;
    private StateMachine _SM;
    private MoveStateGunMan _moveState;
    private AttackState _attackState;
    private Animator _animator;
    [SerializeField] private float _speed = 5;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _SM = new StateMachine();
        _moveState = new MoveStateGunMan(this, _speed, _animator);
        
    }
    private void Start()
    {
        _speed = PlayerPrefs.GetFloat("enemySpeed");
        _SM.Initialize(_moveState);
    }

    private void Update()
    {
        _SM.CurrentState.Update();
        if (transform.position.x > PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-0.7f, transform.localScale.y, transform.localScale.z);
            Pivot.transform.localScale = new Vector3(-1.428571f, Pivot.transform.localScale.y, Pivot.transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);
            Pivot.transform.localScale = new Vector3(1.428571f, Pivot.transform.localScale.y, Pivot.transform.localScale.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<PlayerController>())
        //{
        //    _SM.ChangeState(_attackState);
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<PlayerController>())
        //{
        //    _SM.ChangeState(_moveState);
        //}
    }
}
