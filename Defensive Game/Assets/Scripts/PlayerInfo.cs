using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInfo : MonoBehaviour
{    
    [SerializeField] int initalMoney;
    [SerializeField] int initialLive;    
    public static int Money, Lives, Rounds;


    private void Start()
    {
        Money = initalMoney;
        Lives = initialLive;
        Rounds = 0;        
    }
}
