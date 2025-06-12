

using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "UniqueEffects/Poison")]
public class Poison : UniqueEffect
{
   
    Poison poisoncount;
    public override void Execute(Card card, Card flontCard, Battler player, Enemy enemy, Text message)
    {
        
        enemy.Base.IsPoison = true;//毒状態付与
        message.text += $"\n{enemy.Base.Name1} に毒を付与した！（{enemy.Base.PoisonTurn}ターン）";
        enemy.Base.PoisonCount++;
    }
    
}