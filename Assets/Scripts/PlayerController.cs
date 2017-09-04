using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private InputSet P_InputSet;
    private Player P_Manager;
    private string[] TriggerSet = { "XTrigger", "ZTrigger" };
    private float InputTimer;
    private float LastAxis;

	void Start () {
        P_Manager = GetComponent<Player>();
        P_InputSet = new InputSet(P_Manager.GetPlayerName());
        LastAxis = 0;
    }
	
	void Update () {

        if (InputTimer <= 0) InputTimer = 10;
        else InputTimer -= Time.deltaTime;

        //Movement Value
        float axis = Input.GetAxisRaw(P_InputSet.K_Horizontal);
        bool jump = Input.GetKeyDown(P_InputSet.K_Jump);

        if (Input.GetKeyDown(P_InputSet.K_X))
        {
            P_Manager.IsTrigger("XTrigger");
        }
        else if (Input.GetKeyDown(P_InputSet.K_Z))
        {
            P_Manager.IsTrigger("ZTrigger");
        }
        P_Manager.ChangeVelocity(axis,jump);
    }

    private int GetHash(string HashName)
    {
        return Animator.StringToHash(HashName);
    }

}
