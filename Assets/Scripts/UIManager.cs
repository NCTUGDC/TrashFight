using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Player P_Player;
    private Image HPBar;
    private Text HPAmount;
    private Image MPBar;
    private Text MPAmount;


	void Start () {
        HPBar = transform.Find("HealthBar").Find("Bar").gameObject.GetComponent<Image>();
        MPBar = transform.Find("ManaBar").Find("Bar").gameObject.GetComponent<Image>();
        HPAmount = transform.Find("HealthBar").Find("Amount").gameObject.GetComponent<Text>();
        MPAmount = transform.Find("ManaBar").Find("Amount").gameObject.GetComponent<Text>();
        if (P_Player.GetPlayerName() == "A")
        {
            HPBar.fillOrigin = (int)Image.OriginHorizontal.Right;
            MPBar.fillOrigin = (int)Image.OriginHorizontal.Right;
        }
        else
        {
            HPBar.fillOrigin = (int)Image.OriginHorizontal.Left;
            MPBar.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
    }
	
	void Update () {
        float CHP = P_Player.GetCharacterState().CurrentHP;
        float MHP = P_Player.GetCharacterState().MaxHP;
        float CMP = P_Player.GetCharacterState().CurrentMP;
        float MMP = P_Player.GetCharacterState().MaxMP;

        HPBar.fillAmount = CHP / MHP;
        MPBar.fillAmount = CMP / MMP;
        HPAmount.text = CHP.ToString();
        MPAmount.text = MMP.ToString();
    }
}
