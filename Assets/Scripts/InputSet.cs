using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSet {

    public string K_Horizontal;
    public KeyCode K_Jump;
    public KeyCode K_X;
    public KeyCode K_Z;

    public InputSet(string Player)
    {
        if(Player == "A")
        {
            K_Horizontal = "HorizontalA";
            K_Jump = KeyCode.UpArrow;
            K_X = KeyCode.Comma;
            K_Z = KeyCode.M;
        }else if(Player == "B")
        {
            K_Horizontal = "HorizontalB";
            K_Jump = KeyCode.T;
            K_X = KeyCode.S;
            K_Z = KeyCode.A;
        }
    }
}
