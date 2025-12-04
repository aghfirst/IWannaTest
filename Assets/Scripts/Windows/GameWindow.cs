using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindow : WindowRoot
{
    public GameObject player;
    public GameObject gameOverTip;
    public GameObject[] levelArr;
    
    public Transform startPoint;
    
    private int levelCount;
    
    protected override void InitWindow()
    {
        base.InitWindow();
        levelCount = 0;
        GameStart();
        LoadLevel();
    }

    private void GameStart()
    {
        player.SetActive(true);
        gameOverTip.SetActive(false);
    }

    private void LoadLevel()
    {
        GameObject level = Instantiate(levelArr[levelCount]);
        level.name = "Level" + levelCount;
        level.transform.SetParent(transform, false);
        player.transform.localPosition = level.transform.Find("StartPoint").localPosition;
    }

    private void DeleteLevel()
    {
        Destroy(transform.Find("Level" + levelCount).gameObject);
    }

    public void NextLevel()
    {
        DeleteLevel();
        levelCount++;
        LoadLevel();
    }
    public void GameOver()
    {
        player.SetActive(false);
        gameOverTip.SetActive(true);   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void Restart()
    {
        GameStart();
        DeleteLevel();
        LoadLevel();
    }
}
