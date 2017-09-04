using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager G_Manager;
    [SerializeField]
    private string P_Name;
    private CharacterState P_State;
    private Rigidbody2D P_Rig2D;
    private Animator P_Animator;
    [SerializeField]
    private LayerMask GroundLayer;
    private bool P_Grounded;

    void Start()
    {
        P_State = GetComponent<CharacterState>();
        P_Rig2D = GetComponent<Rigidbody2D>();
        P_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        P_Grounded = Physics2D.Raycast(transform.position, Vector3.down, 1.3f, GroundLayer).distance > 1.15f;
        P_Animator.SetFloat(GetHash("Speed"), Mathf.Abs(P_Rig2D.velocity.x));
        P_Animator.SetFloat(GetHash("FallSpeed"), P_Rig2D.velocity.y);
        P_Animator.SetBool(GetHash("IsGrounded"), P_Grounded);
        CheckRotation(P_Rig2D.velocity.x);
    }

    public void ChangeVelocity(float axis, bool jump)
    {
        Vector2 Next = new Vector2();

        if (P_State.MoveEnable) Next.x = axis * P_State.Dex * 2.7f;
        else Next.x = P_Rig2D.velocity.x;
        if (jump && P_Grounded && P_State.JumpEnable) Next.y = P_State.Dex * 3;
        else Next.y = P_Rig2D.velocity.y;

        P_Rig2D.velocity = Next;
    }

    public void IsTrigger(string trigger)
    {
        P_Animator.SetTrigger(GetHash(trigger));
    }

    private int GetHash(string HashName)
    {
        return Animator.StringToHash(HashName);
    }

    public CharacterState GetCharacterState()
    {
        return P_State;
    }

    public string GetPlayerName()
    {
        return P_Name;
    }

    public void SetGameManager(GameManager G)
    {
        G_Manager = G;
    }

    public void DealDamage(Player target)
    {
        G_Manager.DealDamage(target, (int)(P_State.Str * P_State.AttackRate), transform.position.x);
    }

    public void Hurt(int damage, float targetx)
    {
        P_Rig2D.velocity = new Vector2(0, P_Rig2D.velocity.y);
        P_State.SetHP(P_State.CurrentHP - damage);
        if(P_State.CurrentHP == 0f)
        {
            G_Manager.SomeoneDie(P_Name);
            P_Animator.SetBool(GetHash("IsDead"), true);
        }
        else
        {
            P_Animator.SetFloat(GetHash("Rand"), Random.value);
        }
        IsTrigger("DamageTrigger");
        CheckRotation(targetx - transform.position.x);
    }

    public void Win()
    {
        IsTrigger("WinTrigger");
    }

    private void CheckRotation(float Way)
    {
        if ((transform.rotation.eulerAngles.y >= 180 && Way > 0f) || (transform.rotation.eulerAngles.y < 1 && Way < 0f))
        {
            transform.Rotate(0, 180f, 0);
        }
    }
}