using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    private Image thisImg;
    private GameGlobeData GameCon;
    float fadeSpeed = 1f;

    void Start()
    {
        thisImg = GetComponent<Image>();
        GameCon = GameObject.Find("GameGlobeData").GetComponent<GameGlobeData>();
        GameCon.OnSceneStart += GameCon_OnSceneStart;
        GameCon.OnSceneEnd += GameCon_OnSceneEnd;
    }

    private void GameCon_OnSceneEnd(object sender, System.EventArgs e)
    {
        if (gameObject.tag == "Out")
        {
            float fadeSpeed = 0;
            fadeSpeed += 1 * Time.deltaTime;
            thisImg.color = new Color(thisImg.color.r, thisImg.color.g, thisImg.color.b, fadeSpeed);
            gameObject.SetActive(true);
        }
        else return;
    }

    private void GameCon_OnSceneStart(object sender, System.EventArgs e)
    {     
        if (gameObject.tag == "In")
        {     
            fadeSpeed -= 0.7f * Time.deltaTime;
            thisImg.color = new Color(thisImg.color.r, thisImg.color.g, thisImg.color.b, fadeSpeed);
            if (fadeSpeed <= 0) gameObject.SetActive(false);
            Debug.Log(fadeSpeed);
        }
        else return;
    }
}
