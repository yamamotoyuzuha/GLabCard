﻿using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class RuleBook : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] float pluseffect;

    [SerializeField] Reflector reflector;

    //一枚前のカードの追加効果処理
    /*
    public void FlontEffect(Battler player, Card flontCard)
    {
        if (flontCard == null)
        {
            return;
        }
        else
        {
            player.Attack = (int)(player.Attack * flontCard.Base.CardEffect.Attack_Effect);
            player.MagicAttack = (int)(player.MagicAttack * flontCard.Base.CardEffect.Magic_Effect);
            player.Guard = (int)(player.Guard * flontCard.Base.CardEffect.Protection_Effect);
            player.Heal = (int)(player.Heal * flontCard.Base.CardEffect.Heal_Effect);
        }
    }*/

    //合成カードに掛かる倍率
    /*
    public void TypeEffect(Battler player, Card card)
    {
        if (card.Base.SynthesisType == SynthesisType.Normal)
        {
        }
        else if (card.Base.SynthesisType == SynthesisType.Plus)
        {
            player.Attack = (int)(player.Attack * pluseffect);
            player.MagicAttack = (int)(player.MagicAttack * pluseffect);
            player.Guard = (int)(player.Guard * pluseffect);
            player.Heal = (int)(player.Heal * pluseffect);
        }
    }*/

    //カードの効果処理
    public void selectedCardVS(Battler player, Card card, Card flontCard, Enemy enemy)
    {
        card.Base.UniqueEffect.Execute(card, flontCard, player, enemy, message);

        
        /*if (card.Base.Type == CardType.Sword)
        {
            int Hit = (int)(player.Attack * Random.Range(0.8f, 1.2f));
            float defense = 1f - enemy.Base.EnemyDefense / 100f;
            int damage = (int)(Hit * defense);
            enemy.Base.EnemyLife -= damage;
            kekka.text = $"{damage}ダメージ与えた";
            if (enemy.Base.EnemyLife < 0)
            {
                enemy.Base.EnemyLife = 0;
            }
        }
        else if (card.Base.Type == CardType.Witchcraft)
        {

            int Hit = (int)(player.MagicAttack * Random.Range(0.8f, 1.2f));
            float defense = 1f - enemy.Base.EnemyMagicDefense / 100f;
            int damage = (int)(Hit * defense);
            enemy.Base.EnemyLife -= damage;
            kekka.text = $"{damage}魔法ダメージあたえた";
            if (enemy.Base.EnemyLife < 0)
            {
                enemy.Base.EnemyLife = 0;
            }
        }
        else if (card.Base.Type == CardType.Protection)
        {

            player.Defens += player.Guard;
            if(player.Defens > 100)
            {
                player.Defens = 100;
            }
            kekka.text = $"{player.Defens}ぼうぎょがあがった";
        }
        else if (card.Base.Type == CardType.Heal)
        {

            if ((player.Life + player.Heal) > player.LifeMax)
            {
                player.Heal = player.LifeMax - player.Life;
            }
            player.Life += player.Heal;
            kekka.text = $"{player.Heal}HPかいふくした";
        }*/

    }

    //エネミーの強力攻撃までのカウントダウン
    public void EnemyCountDown(Enemy enemy)
    {
        if (enemy.Base.Count1 == 0)
        {
            enemy.Base.Count1 = enemy.Base.EnemyCount;
            enemy.CountText1.text = $"{enemy.Base.Count1}";
        }
        else
        {
            enemy.Base.Count1 = enemy.Base.Count1 - 1;
            enemy.CountText1.text = $"{enemy.Base.Count1}";
        }
    }

    //敵のターン処理
    public void EnemyAttack(Battler player, Enemy enemy)
    {


        if (enemy.Base.IsRaigeki == true)
        {
            message.text = $"行動不能";
            
        }
        else 
        {
            int Hit = (int)(enemy.Base.EnemyAttack * Random.Range(0.8f, 1.1f));
            float Decrease = 1f - player.Defens / 100f;

            if (enemy.Base.Count1 == 0)
            {
                Hit = 2 * Hit;
            }
            Hit = (int)(Hit * Decrease);

            //リフレクターの処理
            if (reflector.isReflector){
                reflector.ReflectorAttack(player, enemy, message, Hit);
                message.text = $"{reflector.enemyDamagae}ダメージをうけた";
                return;
            }

            if (enemy.CheckSleep()) return;
            
            player.Life -= Hit;
            message.text = $"{Hit}ダメージをうけた";
        }
        enemy.Base.IsRaigeki = false;
        
        if(enemy.Base.IsPoison)
        {
            Debug.Log(enemy.Base.PoisonTurn);

            var adddamege = 5;//重複による追加ダメージ
            Debug.Log(enemy.Base.IsPoison);
            if (enemy.Base.PoisonTurn == 0)
            {
                enemy.Base.EnemyLife -= 10;
                enemy.Base.PoisonTurn++;
            }
            else if (enemy.Base.PoisonTurn == 1)
            {
                if (enemy.Base.PoisonCount >= 2)
                {
                    Debug.Log(enemy.Base.EnemyLife);
                    enemy.Base.EnemyLife -= (15 + adddamege);
                    enemy.Base.PoisonTurn++;
                    return;
                }
                enemy.Base.EnemyLife -= 15;
                enemy.Base.PoisonTurn++;
            }
            else if (enemy.Base.PoisonTurn == 2)
            {
                if (enemy.Base.PoisonCount >= 2)
                {
                    enemy.Base.EnemyLife -= (20 + adddamege);
                    enemy.Base.PoisonTurn++;
                    return;
                }
                enemy.Base.EnemyLife -= 20;
                enemy.Base.PoisonTurn++;
            }
            else if (enemy.Base.PoisonTurn == 3)
            {
                if (enemy.Base.PoisonCount >= 2)
                {
                    enemy.Base.EnemyLife -= (25 + adddamege);
                    enemy.Base.PoisonTurn++;
                    return;
                }
                enemy.Base.EnemyLife -= 25;
                enemy.Base.PoisonTurn++;
            }
            else if (enemy.Base.PoisonTurn == 4)
            {
                
                if (enemy.Base.PoisonCount >= 1)
                {
                    enemy.Base.EnemyLife -= 30;
                    enemy.Base.PoisonCount--;
                    return;
                }
                enemy.Base.EnemyLife -= 30;
                enemy.Base.IsPoison = false;
                enemy.Base.PoisonTurn = 0;
            }
            
            

           
        }
        
       

    }

    //敵の状態表示
    public void EnemyParLife(Enemy enemy)
    {
        float RestLife = (float)enemy.Base.EnemyLife / (float)enemy.Base.EnemyLifeMax;

        if (RestLife == 1f)
        {
            message.text = "全く傷ついていない！";
        }
        else if (RestLife > 0.7f)
        {
            message.text = $"{enemy.Base.Name1}はピンピンしている";
        }
        else if (RestLife > 0.4f)
        {
            message.text = $"{enemy.Base.Name1}は疲れ始めている";
        }
        else
        {
            message.text = $"{enemy.Base.Name1}はもうボロボロだ！";
        }
    }

    //結果のテキストリセット
    public void TextSetupNext()
    {
        message.text = "";
    }
}
