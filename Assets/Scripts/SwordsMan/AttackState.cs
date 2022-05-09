using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private SwordsMan _enemy;
    private Animator _anim;
    public AttackState(SwordsMan enemy, Animator anim)
    {
        _enemy = enemy;
        _anim = anim;
    }
    public override void Enter()
    {
        base.Enter();
        _anim.Play("SwordsAttack");
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        
    }
}
