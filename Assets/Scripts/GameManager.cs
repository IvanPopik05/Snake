using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Blocks Color")]

    public Color EasyColor, MiddleColor, HardColor, ImpossiblyColor;
    [Header("Settings Block")]
    public int maxAmountBlock = 50;
    public float damageTime = 0.5f;
    public float ObstaclesDistance = 13f;
    public TMP_Text TextamountObstacles;
    public float amountObstacles;
    public RepeatAdditive repeatAdditive;
    public Vector2 xLimit;
    private Transform snake;
    public SceneFader sceneFader;
    public string sceneName = "GameScene";

    private void Start()
    {
        snake = FindObjectOfType<SnakeTail>().transform;
        SpawnAdditive();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Repeat();
        }
    }
    public void SetAmountObstacles() 
    {
        TextamountObstacles.text = amountObstacles.ToString();
    }

    void SpawnAdditive() 
    {
        repeatAdditive.GetObject().transform.position = new Vector2(Random.Range(xLimit.x,xLimit.y), snake.transform.position.y + Random.Range(10,30));
        Invoke("SpawnAdditive", Random.Range(2f,10f));
    }
    public void Repeat() 
    {
        sceneFader.FadeTo(sceneName);
    }
}
