using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UniqueEffects/Anesthesia")]
public class AnesthesiaEffect : UniqueEffect
{
    [Header("麻酔の確率")]
    [SerializeField]
    public List<float> sleepProbabilities = new List<float> { 0.66f, 0.33f };
    [Header("継続ターン数")]
    public int duration = 2;


    //カードの効果処理
    public override void Execute(Card card, Card flontCard, Battler player,Enemy enemy,Text message)
    {
        enemy.ApplySleep(sleepProbabilities, duration);
        message.text = "敵に麻酔ポーションをかけた";

        
    }
    //一枚前のカードの追加効果処理
    public int FlontBuff(Card card, Card flontCard)
    {
        
        float attackValue = (int)card.Base.CardStatus.Attack_Status;
        
        
        if (flontCard == null)
        {
            return (int)attackValue;
        }
        else
        {
            string cardName = flontCard.Base.CardName;
            FlontBuff foundBuff = card.Base.FlontBuff.Find(buff => buff.flontCard == cardName);

            if (foundBuff == null)
            {
                return (int)attackValue;
            }
            attackValue *= foundBuff.buff;
            return (int)attackValue;
        }
        

    }
}
