using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update

    public MusicController musicController;

  

    public void OnStartButtan()
    {   
        SceneManager.LoadScene("GameScene");

    }

    public void Start()
    {
        musicController.PlayTitleBGM();
    }

}
