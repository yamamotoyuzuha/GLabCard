using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UniqueEffects/Blood")]
public class BloodEffect : UniqueEffect
{
    //カードの効果処理
    public override void Execute(Card card, Card flontCard, Battler player,Enemy enemy,Text message)
    {
        int bloodValue = FlontBuff(card, flontCard);
        
        int healValue = (int)FlontBuff(card, flontCard);
        
        int Hit = (int)(bloodValue * Random.Range(0.8f, 1.2f));

        float defense = 1f - enemy.Base.EnemyDefense / 100f;


        int damage = (int)(Hit * defense);

        enemy.Base.EnemyLife -= damage;

        enemy.isSleepingBroken = true;

        Debug.Log(damage);

        //message.text = $"{damage}ダメージ与えた";

        //体力の上限以上に回復しないよう調整
        if ((player.Life + damage) > player.LifeMax)
        {
            //(/*条件分岐の外で宣言した回復変数*/) = (MaxHP) - (HP);

            //上限以上回復した場合の回復量
            healValue = player.LifeMax - player.Life;
        }
        else //上限よりも回復しなかった場合の回復量
        {
            healValue = damage;
        }

            player.Life += healValue;

        message.text = $"{healValue}HP吸血した！";




        if (enemy.Base.EnemyLife < 0)
        {
            enemy.Base.EnemyLife = 0;
        }

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
