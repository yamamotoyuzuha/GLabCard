using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UniqueEffects/Attack")]
public class AttackEffect : UniqueEffect
{
    //カードの効果処理
    public override void Execute(Card card, Card flontCard, Battler player,Enemy enemy,Text message)
    {
        int attackValue = FlontBuff(card, flontCard);

        int Hit = (int)(attackValue * Random.Range(0.8f, 1.2f));
        float defense = 1f - enemy.Base.EnemyDefense / 100f;

        //代償カードのバフ計算　各カードのスクリプタブルオブジェクトのBuffに代償カードを追加すればOK
        /*
        int damage = 0;
        if(card.Base.ComBuff != 0)
        {
            damage = (int)(Hit * defense) * (int)card.Base.ComBuff;
        }
        else
        {
            damage = (int)(Hit * defense);
        }
        */
        int damage = (int)(Hit * defense);
        enemy.Base.EnemyLife -= damage;
        message.text = $"{damage}ダメージ与えた";
        if (enemy.Base.EnemyLife < 0)
        {
            enemy.Base.EnemyLife = 0;
        }

        //card.Base.ComBuff = 0; //バフを解除
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
