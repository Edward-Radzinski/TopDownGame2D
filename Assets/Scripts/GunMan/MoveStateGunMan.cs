using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStateGunMan : State
{
    private Animator _anim;
    private GunMan _enemy;
    private float _speed;
    public MoveStateGunMan(GunMan enemy, float speed,Animator anim)
    {
        _enemy = enemy;
        _speed = speed;
        _anim = anim;
    }
    public override void Enter()
    {
        base.Enter();
        _anim.Play("GunManWalk");
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
