using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private SwordsMan _enemy;
    private Animator _anim;
    private float _speed;
    public MoveState(SwordsMan enemy, float speed,Animator anim)
    {
        _enemy = enemy;
        _speed = speed;
        _anim = anim;
    }
    public override void Enter()
    {
        base.Enter();
        _anim.Play("SwordsManWalk");
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, PlayerController.instance.transform.position, _speed * Time.deltaTime);
    }
}
