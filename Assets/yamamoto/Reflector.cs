using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.VersionControl;
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

    public void ReflectorAttack(Battler player, Enemy enemy, Text message, int Hit) //リフレクターの処理
    {
        if (isReflector)
        {
            float enemyDamagae = Hit * 0.5f; //Enemyのダメージを半減
            player.Life -= (int)enemyDamagae;
            Debug.Log(enemyDamagae);

            //Enemyにダメージを与える処理
            int reflectorDamage = (int)enemyDamagae * 3;
            enemy.Base.EnemyLife -= reflectorDamage;
            message.text = $"{reflectorDamage}ダメージを反射で与えた";
            Debug.Log(reflectorDamage);

            //reflector.isReflector = false;
            isReflector = false;

            Debug.Log("リフレクターの処理を終了");

            enemy.EnemyLifeContlloer.lifeReflection(enemy);
        }
    }
}
