using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour {

    public enum TriggerType { Attack, Block, Damage };
    private Player P_Player;
    [SerializeField]
    private TriggerType T_Type;
    private TriggerType TargetType;

    void Start()
    {
        P_Player = transform.parent.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        TargetType = GetTargetTriggerType(other);
        if (T_Type == TriggerType.Attack && TargetType == TriggerType.Damage)
        {
            P_Player.DealDamage(GetTargetPlayer(other));
        }
    }

    public TriggerType GetTriggerType()
    {
        return T_Type;
    }

    private TriggerType GetTargetTriggerType(Collider2D other)
    {
        return other.transform.gameObject.GetComponent<TriggerDetector>().GetTriggerType();
    }

    private Player GetTargetPlayer(Collider2D other)
    {
        return other.transform.parent.GetComponent<Player>();
    }
}
