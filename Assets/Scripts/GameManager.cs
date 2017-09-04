using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Player PlayerA;
    private Player PlayerB;
    [SerializeField]
    private Canvas MainCanvas;

	// Use this for initialization
	void Start () {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject P in Players)
        {
            P.GetComponent<Player>().SetGameManager(this);
            if (P.GetComponent<Player>().GetPlayerName() == "A") PlayerA = P.GetComponent<Player>();
            else if (P.GetComponent<Player>().GetPlayerName() == "B") PlayerB = P.GetComponent<Player>();
        }
    }

    public void DealDamage(Player target, int damage, float position)
    {
        target.Hurt(damage, position);
    }

    public void SomeoneDie(string P_Name)
    {
        if(P_Name == PlayerA.GetPlayerName())
        {
            PlayerB.Win();
        }
        else
        {
            PlayerA.Win();
        }
    }

}
