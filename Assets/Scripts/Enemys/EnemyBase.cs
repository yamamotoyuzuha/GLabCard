using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu]
public class EnemyBase : ScriptableObject
{
    
    [SerializeField] int poisonTurn = 0;      // 毒状態が続くターン数
    [SerializeField] int poisonDamage = 0;
    [SerializeField] bool ispoison; //毒状態
    [SerializeField] int poisonCount;//重複されて数
    [SerializeField] bool israigeki;//行動不能状態かどうか
    [SerializeField] int raigekiCount; //何回つかったか
    [Header("エネミーの種類")]
    [SerializeField] Sprite icon;
    [SerializeField] string Name;
    [SerializeField] EnemyType type;
    [Space(10)]
    [Header("エネミーステータス")]
    [SerializeField] int enemyLifeMax;
    int enemyLife;
    [SerializeField] int enemyAttack;
    [SerializeField] int enemyDefense;
    [SerializeField] int enemyMagicDefense;
    
    [Space(10)]
    [Header("強攻撃")]
    [SerializeField] int enemyCount;
    int Count;
    [TextArea]
    [SerializeField] string description;

    [SerializeField, Header("確率"), Range(0, 100)]
    private int[] Weights = new int[3];
    private void Awake()
    {
        raigekiCount = 0;
    }







    public EnemyType Type { get => type; set => type = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public string Description { get => description; set => description = value; }
    public string Name1 { get => Name; set => Name = value; }
    public int EnemyAttack { get => enemyAttack; set => enemyAttack = value; }
    public int EnemyLife { get => enemyLife; set => enemyLife = value; }
    public int EnemyLifeMax { get => enemyLifeMax; set => enemyLifeMax = value; }
    public int EnemyDefense { get => enemyDefense; set => enemyDefense = value; }
    public int EnemyMagicDefense { get => enemyMagicDefense; set => enemyMagicDefense = value; }
    public int EnemyCount { get => enemyCount; set => enemyCount = value; }
    public int Count1 { get => Count; set => Count = value; }
    public int[] Weights1 { get => Weights; set => Weights = value; }
    public int PoisonTurn { get => poisonTurn; set => poisonTurn = value; }
    public int PoisonDamage { get => poisonDamage; set => poisonDamage = value; }
    public bool IsPoison { get => ispoison; set => ispoison = value; }
    public int PoisonCount { get => poisonCount; set => poisonCount = value; }
    public bool IsRaigeki {  get => israigeki; set => israigeki = value;}
    public int RaigekiCount {  get => raigekiCount; set => raigekiCount = value; }




}


public enum EnemyType
{
    Slime,
    Golem,
    Dragon,
}
