using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UniqueEffects/Compensation")]
public class Compensation : UniqueEffect
{
    //カードの効果処理
    public override void Execute(Card card, Card flontCard, Battler player, Enemy enemy, Text message)
    {
        int compensationValue = (int)FlontBuff(card, flontCard);

        int hit = (int)(compensationValue * Random.Range(0.8f, 1.2f));
        float defense = 1f - enemy.Base.EnemyDefense / 100f;
        int damage = (int)(hit * (defense * card.Base.ComMagnification));

        player.Life -= player.Compensation; //代償でHPを引く
        
        enemy.Base.EnemyLife -= damage;
        message.text = $"{damage}の代償ダメージを与えた";

        if (enemy.Base.EnemyLife < 0)
        {
            enemy.Base.EnemyLife = 0;
        }

        //仕様変更あり
        //固定値になる可能性がある
    }

    //一枚前のカードの追加効果
    public float FlontBuff(Card card, Card flontCard)
    {
        //Swordのattack値を参照する
        var obj = GameObject.Find("CardGenerator");
        var cardGe = obj.GetComponent<CardGenerator>();
        var getSword = cardGe.CardBases.Find(x => x.CardName == "Sword");

        float compensationValue = (int)getSword.CardStatus.Attack_Status;
        
        if(flontCard == null)
        {
            return (int) compensationValue;
        }
        /*
        else //次のカードにバフをかける　スクリプタブルオブジェクトでやればOKだからいらない
        {
            string cardName = flontCard.Base.CardName; //代償カードの次のカードの名前を取得する
            Debug.Log(cardName);

            flontCard.Base.ComBuff = 5; //次のカードにバフの値を代入
            return (int)compensationValue;
        }
        */
        else
        {
            string cardName = flontCard.Base.CardName;
            FlontBuff foundBuff = card.Base.FlontBuff.Find(buff => buff.flontCard == cardName);

            if (foundBuff == null)
            {
                return (int)compensationValue;
            }
            compensationValue *= foundBuff.buff;
            return (int)compensationValue;
        }
    }
}
