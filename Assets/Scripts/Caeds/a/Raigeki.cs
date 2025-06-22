using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UniqueEffects/Raigeki")]
public class RaigekiEffect : UniqueEffect
    
{
    
    private static System.Random rng = new System.Random(); // 毎回作らず static で使い回す
    //カードの効果処理
    public override void Execute(Card card, Card flontCard, Battler player, Enemy enemy, Text message)
    {
        int RaigekiValue = (int)card.Base.CardStatus.Raigeki_Status;

        //int Hit = (int)(RaigekiValue);
        //float defense = 1f - enemy.Base.EnemyDefense / 100f;
        //int damage = (int)(Hit * defense);

        int damage = Random.Range(10, 15);

        Debug.Log(damage);
        enemy.Base.EnemyLife -= damage;
        //message.text = $"{damage}ダメージ与えた"; //＝＞動いていなかったので一旦コメント化しておきました。
        if (enemy.Base.EnemyLife < 0)
        {
            enemy.Base.EnemyLife = 0;
        }
        enemy.Base.RaigekiCount++;
        Debug.Log(enemy.Base.RaigekiCount);

        if (enemy.Base.RaigekiCount == 4)
        {
            // 4回目なら確定で発動
            enemy.Base.IsRaigeki = true;
            message.text = $"{damage}ダメージを与え、\n雷撃が確定で発動した！（4回目）";
            enemy.Base.RaigekiCount = 0;
        }
        else
        {
            int chance = rng.Next(100); // 0〜99

            if (chance < 5)
            {
                // 5%の確率で発動
                enemy.Base.IsRaigeki = true;
                message.text = "雷撃が発動した！";
            }
            else
            {
                // 発動しなかった
                message.text = $"{damage}ダメージを与えたが、発動しなかった！";
            }
        }
    }
}
    //一枚前のカードの追加効果処理
   /* public int FlontBuff(Card card, Card flontCard)
    {

        float RaigekiValue = (int)card.Base.CardStatus.Raigeki_Status;


        if (flontCard == null)
        {
            return (int)RaigekiValue;
        }
        else
        {
            string cardName = flontCard.Base.CardName;
            FlontBuff foundBuff = card.Base.FlontBuff.Find(buff => buff.flontCard == cardName);

            if (foundBuff == null)
            {
                return (int)RaigekiValue;
            }
            RaigekiValue *= foundBuff.buff;
            return (int)RaigekiValue;
        }


    }
}*/
