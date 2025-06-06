using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text descriotionText;
    [SerializeField] Text CountText;
    public EnemyBase Base { get; private set; }
    public EnemyBase Status { get; private set; }
    public Text DescriotionText { get => descriotionText; set => descriotionText = value; }
    public Text CountText1 { get => CountText; set => CountText = value; }

    private EnemyLifeContlloer enemyLifeContlloer;
    public EnemyLifeContlloer EnemyLifeContlloer { get => enemyLifeContlloer; set => enemyLifeContlloer = value; }

    public UnityAction<Card> OnClickCard;

    private List<float> sleepRates = new List<float>();
    private int sleepTurn = 0;
    private bool isSleepActive = false;
    private bool isSleepingBroken = false;
    private int maxSleepTurns = 0;




    //カード内容の定義
    public void SetEnemy(EnemyBase enemyBase)
    {
        enemyBase.EnemyLife = enemyBase.EnemyLifeMax;
        enemyBase.Count1 = enemyBase.EnemyCount;
        Base = enemyBase;
        icon.sprite = enemyBase.Icon;
        descriotionText.text = enemyBase.Description;
        CountText1.text = $"{enemyBase.Count1}";
        EnemyLifeContlloer = GetComponent<EnemyLifeContlloer>();
    }
    //麻酔処理
    public void ApplySleep(List<float> rates, int maxTurns)
    {
        
        sleepRates = new List<float>(rates);
        sleepTurn = 0;
        isSleepActive = true;
        isSleepingBroken = false;
        maxSleepTurns = maxTurns;
       
    }
    public bool CheckSleep()
    {
        if (!isSleepActive || isSleepingBroken)
        {
            //Debug.Log("眠り状態じゃない or ダメージで解除された");
            return false;
        }

        if (sleepTurn >= maxSleepTurns)
        {
            Debug.Log("眠りのターン終了");
            isSleepActive = false;
            return false;
        }

        float chance = sleepRates[sleepTurn];
        float randomValue = Random.value;
        //Debug.Log($"[Sleep判定] Turn:{sleepTurn}, 確率:{chance}, 値:{randomValue}");

        sleepTurn++;

        if (randomValue < chance)
        {
            Debug.Log("敵は眠っている！");
            return true;
        }
        else
        {
            Debug.Log("敵は起きてしまった！");
            isSleepActive = false;
            return false;
        }
    }

    public void OnDamaged()
    {
        if (isSleepActive)
        {
            isSleepingBroken = true;
            isSleepActive = false;
        }
    }
}



 
