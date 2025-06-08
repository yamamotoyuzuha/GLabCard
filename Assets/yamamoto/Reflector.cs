using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UniqueEffects/Reflector")]
public class Reflector : UniqueEffect
{
    public bool isReflector;
    
    //カードの効果処理
    public override void Execute(Card card, Card flontCard, Battler player, Enemy enemy, Text message)
    {
        message.text = $"攻撃を反射できるようになった";
        isReflector = true ; //反射状態にする
    }
}
