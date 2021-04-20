using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI liveTMP;
    [SerializeField] TextMeshProUGUI moneyTMP;
    [SerializeField] TextMeshProUGUI roundTMP;
    public int MaxRound { get; set; }
    // Update is called once per frame
    void Update()
    {
        liveTMP.text = PlayerInfo.Lives.ToString();
        moneyTMP.text = PlayerInfo.Money.ToString();
        roundTMP.text = PlayerInfo.Rounds.ToString() + "/" + MaxRound.ToString();
    }
}
