using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class MusicController : MonoBehaviour
   
{
    //メモ必要BGM
    /*タイトルBGM　ステージセレクトBGM　勝利BGM　
     * 通常バトルスタート　通常バトル
     * ドラゴンバトルスタート　ドラゴンバトル　の７つ*/
    public AudioClip titleBGM;

    public AudioClip stage_selectBGM;

    public AudioClip nomal_battle_startBGM;
    public AudioClip nomal_battleBGM;

    public AudioClip dragon_battle_startBGM;
    public AudioClip dragon_battleBGM;

    public AudioClip victoryBGM;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
    }

    //タイトルBGMの再生
    public void PlayTitleBGM()
    {   

        audioSource.clip = titleBGM;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    //ステージセレクトの再生
    public void StageSelectBGM()
    {
        audioSource.clip = stage_selectBGM;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    //通常の敵のバトルスタート音の再生
    public void NomalBattleStartBGM()
    {   
        audioSource.loop = false;
        audioSource.clip = nomal_battle_startBGM;
        audioSource.volume = 1.0f;
        audioSource.Play();

        //nomal_battle_startBGMの曲の長さ分待ってから、ループ処理に切り替わるようにする
        StartCoroutine(SwitchToLoop(nomal_battle_startBGM.length , nomal_battleBGM));
    }

    

    //ドラゴン戦のスタート音の再生
    public void DragonBattleStartBGM()
    {
        audioSource.clip = dragon_battle_startBGM;
        audioSource.volume = 0.7f;
        audioSource.Play();

        //nomal_battle_startBGMの曲の長さ分待ってから下のループ処理に切り替わるようにする
        StartCoroutine(SwitchToLoop(dragon_battle_startBGM.length, dragon_battleBGM));
    }

    //スタートからバトルBGMのループに移行する処理
    private IEnumerator SwitchToLoop(float delay, AudioClip nextClip)//指定時間(nomal_battle_startBGM)待ってから下の処理に入る
    {
        yield return new WaitForSeconds(delay);//曲の秒数分、待機する
        audioSource.clip = nextClip;
        audioSource.loop = true;
        audioSource.Play();
    }




    

    //勝利BGMの再生
    public void VictoryBGM()
    {   
        audioSource.loop = false;
        audioSource.clip = victoryBGM;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }




    // Update is called once per frame
    void Update()
    {



        
    }
}
