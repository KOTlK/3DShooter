using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI 
{
    private Text _hp;

    public InGameUI (Text hpText)
    {
        _hp = hpText;
    }
    public void UpdateUI()
    {
        _hp.text = $"Hp: {Player.S.CurrentHP}";
    }

}
