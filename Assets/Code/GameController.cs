﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public NejikoController nejiko;
    public Text scoreText;
    public LifePanel lifePanel;

    public void Update()
    {
        //スコアを更新
        int score = CalcScore();
        scoreText.text = "Score:" + score + "m";

        //ライフパネルを更新
        lifePanel.UpdateLife(nejiko.Life());

        //ねじ子のライフが0になったらゲームオーバー
        if (nejiko.Life() <= 0)
        {
            //これ以降のupdateはやめる
            enabled = false;

            //ハイスコアを更新
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            //2秒後にReturnToTitleを呼び出す
            Invoke("ReturnToTitle", 2.0f);
        }
    }

    int CalcScore()
    {
        //ねじ子の走行距離をスコアとする
        return (int)nejiko.transform.position.z;
    }

    void ReturnToTitle()
    {
        //タイトルシーンに切り替え
        SceneManager.LoadScene("Title");
    }
}
