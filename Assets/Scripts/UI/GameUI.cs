﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Reaction reaction;
    [SerializeField] Text playerLifeText;
    [SerializeField] Text TurnText;
    [SerializeField] Text PoisonTurnText;
    [SerializeField] Text TurnResultText;
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject deckPanel;
    [SerializeField] GameObject rulePanel;
    [SerializeField] Text resultText;
    [SerializeField] Text ruleText1;
    [SerializeField] Text ruleText2;
    [SerializeField] Text ruleText3;
    [SerializeField] Text ruleText4;
    [SerializeField] Text ruleText5;
    [SerializeField] Text ruleText6;
    [SerializeField] GameObject proceedButton;
    [SerializeField] GameObject returnButton;
    [SerializeField] GameObject massagePanel;
    [SerializeField] Text kekka;
    Enemy enemy;
    public GameObject RulePanel { get => rulePanel; set => rulePanel = value; }
    public GameObject DeckPanel { get => deckPanel; set => deckPanel = value; }
    public GameObject MassagePanel { get => massagePanel; set => massagePanel = value; }


    //UIの非表示化
    public void UISetUp()
    {
        massagePanel.SetActive(false);
        resultPanel.SetActive(false);
        rulePanel.SetActive(false);
        SetRuleText();
        deckPanel.SetActive(false);
    }

    public void SetRuleText()
    {
        returnButton.SetActive(false);
        ruleText1.gameObject.SetActive(true);
        ruleText2.gameObject.SetActive(false);
        ruleText3.gameObject.SetActive(false);
        ruleText4.gameObject.SetActive(false);
        ruleText5.gameObject.SetActive(false);
        ruleText6.gameObject.SetActive(false);
    }

    //数字追加のUIを表示するかしないかの判別

    //ライフの表示・変更
    public void ShowLifes(int playerLife)
    {
        playerLifeText.text = $"{playerLife}";

    }

    //経過ターン数をカウントする
    public void ShowTurn(int turnCount)
    {

        TurnText.text = $"ターン {turnCount}";



    }

    //ゲームの勝敗をパネルで表示
    public void ShowGameResult(string result , int turnCount)
    {
        resultPanel.SetActive(true);
        resultText.text = result;
        if (result == "WIN")
        {
            TurnResultText.gameObject.SetActive(true);
            TurnResultText.text = $"経過ターン：{turnCount}";
        }
        else
        {
            TurnResultText.gameObject.SetActive(false);
        }
    }

    public void Proceed()
    {
        if (ruleText1.gameObject.activeSelf)
        {
            ruleText1.gameObject.SetActive(false);
            ruleText2.gameObject.SetActive(true);
            returnButton.SetActive(true);
        }
        else if (ruleText2.gameObject.activeSelf)
        {
            ruleText2.gameObject.SetActive(false);
            ruleText3.gameObject.SetActive(true);
        }
        else if (ruleText3.gameObject.activeSelf)
        {
            ruleText3.gameObject.SetActive(false);
            ruleText4.gameObject.SetActive(true);
        }
        else if (ruleText4.gameObject.activeSelf)
        {
            ruleText4.gameObject.SetActive(false);
            ruleText5.gameObject.SetActive(true);
        }
        else if (ruleText5.gameObject.activeSelf)
        {
            ruleText5.gameObject.SetActive(false);
            ruleText6.gameObject.SetActive(true);
            proceedButton.SetActive(false);
            Reaction riaction = proceedButton.GetComponent<Reaction>();
            riaction.ButtonReSet();
        }
    }

    public void ReturnAA()
    {
        if (ruleText2.gameObject.activeSelf)
        {
            ruleText2.gameObject.SetActive(false);
            ruleText1.gameObject.SetActive(true);
            returnButton.SetActive(false);
            Reaction riaction = returnButton.GetComponent<Reaction>();
            riaction.ButtonReSet();
        }
        else if (ruleText3.gameObject.activeSelf)
        {
            ruleText3.gameObject.SetActive(false);
            ruleText2.gameObject.SetActive(true);
        }
        else if (ruleText4.gameObject.activeSelf)
        {
            ruleText4.gameObject.SetActive(false);
            ruleText3.gameObject.SetActive(true);
        }
        else if (ruleText5.gameObject.activeSelf)
        {
            ruleText5.gameObject.SetActive(false);
            ruleText4.gameObject.SetActive(true);
        }
        else if (ruleText6.gameObject.activeSelf)
        {
            ruleText6.gameObject.SetActive(false);
            ruleText5.gameObject.SetActive(true);
            proceedButton.SetActive(true);
        }

    }


    public IEnumerator Sengen(Enemy enemy)
    {
        switch (enemy.Base.Type)
        {
            case EnemyType.Slime:
                kekka.text = $"{enemy.Base.Name1}の攻撃";
                yield return new WaitForSeconds(1f);
                kekka.text = ($"{enemy.Base.Name1}の溶解液！");
                yield return new WaitForSeconds(1.2f);
                break;
            case EnemyType.Golem:
                kekka.text = $"{enemy.Base.Name1}の攻撃";
                yield return new WaitForSeconds(1f);
                kekka.text = ($"{enemy.Base.Name1}のグレートパンチ！");
                yield return new WaitForSeconds(1.2f);
                break;
            case EnemyType.Dragon:
                kekka.text = ($"{enemy.Base.Name1}の攻撃");
                yield return new WaitForSeconds(1f);
                kekka.text = ($"{enemy.Base.Name1}のファイアブレス！");
                yield return new WaitForSeconds(1.2f);
                break;
        }
    }
    public void show_text(Enemy enemy)
    {
        kekka.text = $"{enemy.Base.Name1}は眠っている！";

    }


}
