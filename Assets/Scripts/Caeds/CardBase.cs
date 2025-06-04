﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CardBase : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] string displayName;
    [SerializeField] string cardName;
    [SerializeField] SynthesisType synthesisType;
    [SerializeField] CardType type;
    [SerializeField] int id;
    [SerializeField] Sprite icon;
    [SerializeField] Color color;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] CardStatus cardStatus;

    //[SerializeField] CardEffect cardEffect;

    [SerializeField] UniqueEffect uniqueEffect;
    [SerializeField] List<FlontBuff> flontBuff = new List<FlontBuff>();

    [SerializeField] float compensationMagnification; //代償カードの倍率
    //[SerializeField] float compensationBuff; //代償カードが与えるバフ

    public CardType Type { get => type; set => type = value; }
    public int ID { get => id; set => id = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public string Description { get => description; set => description = value; }
    public string DisplayName { get => displayName; set => displayName = value; }
    public string CardName { get => cardName; set => cardName = value; }
    public Color Color { get => color; set => color = value; }
    public SynthesisType SynthesisType { get => synthesisType; set => synthesisType = value; }
    //public CardEffect CardEffect { get => cardEffect; set => cardEffect = value; }
    public UniqueEffect UniqueEffect { get => uniqueEffect; set => uniqueEffect = value; }
    public List<FlontBuff> FlontBuff { get => flontBuff; set => flontBuff = value; }
    public CardStatus CardStatus { get => cardStatus; set => cardStatus = value; }

    public float ComMagnification { get => compensationMagnification; }
    //public float ComBuff { get => compensationBuff; set => compensationBuff = value; }


}

public enum CardType
{
    Attack,
    Defense,
    Heal,
    exception,
    poison,
    Compensation,
    reflector,
}

public enum SynthesisType
{
    Normal,
    Plus,
    DoublePlus,
}

[Serializable]
public class CardStatus
{
    [SerializeField] float attack_Status;
    [SerializeField] float magic_Status;
    [SerializeField] float defense_Status;
    [SerializeField] float heal_Status;

    public float Attack_Status { get => attack_Status; set => attack_Status = value; }
    public float Magic_Status { get => magic_Status; set => magic_Status = value; }
    public float Defense_Status { get => defense_Status; set => defense_Status = value; }
    public float Heal_Status { get => heal_Status; set => heal_Status = value; }
}

//後ろのカードに与えるエフェクト
/*
[Serializable]
public class CardEffect
{
    [SerializeField] float attack_Effect;
    [SerializeField] float magic_Effect;
    [SerializeField] float protection_Effect;
    [SerializeField] float heal_Effect;

    public float Attack_Effect { get => attack_Effect; set => attack_Effect = value; }
    public float Magic_Effect { get => magic_Effect; set => magic_Effect = value; }
    public float Protection_Effect { get => protection_Effect; set => protection_Effect = value; }
    public float Heal_Effect { get => heal_Effect; set => heal_Effect = value; }
}
*/

[System.Serializable]
public class FlontBuff
{
    public float buff;
    public string flontCard ;
}



