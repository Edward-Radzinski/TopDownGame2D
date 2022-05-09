using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsMan : MonoBehaviour
{
    private StateMachine _SM;
    private MoveState _moveState;
    private AttackState _attackState;
    private Animator _animator;
    [SerializeField] private float _speed = 5;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _SM = new StateMachine();
        _moveState = new MoveState(this, _speed, _animator);
        _attackState = new AttackState(this, _animator);
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
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _SM.ChangeState(_attackState);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _SM.ChangeState(_moveState);
        }
    }
}
