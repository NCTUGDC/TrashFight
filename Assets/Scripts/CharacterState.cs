using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public int MaxHP { get; private set; }
    public int MaxMP { get; private set; }
    public int Str { get; private set; }
    public int Dex { get; private set; }
    public int CurrentHP { get; private set; }
    public int CurrentMP { get; private set; }

    public bool JumpEnable;
    public bool MoveEnable;
    public float AttackRate;

    public Effect P_Effect = new Effect();

    public CharacterState()
    {
        MaxHP = 1000;
        MaxMP = 300;
        Str = 10;
        Dex = 4;
        CurrentHP = MaxHP;
        CurrentMP = MaxMP;
        JumpEnable = true;
        MoveEnable = true;
        AttackRate = 1f;
        P_Effect.E_Type = Effect.EffectType.None;
    }

    public void SetHP(int value)
    {
        if (value < 0) value = 0;
        CurrentHP = value;
    }

    public void SetMP(int value)
    {
        if (value < 0) value = 0;
        CurrentMP = value;
    }
}
