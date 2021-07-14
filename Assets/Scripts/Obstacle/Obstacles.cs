using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Obstacle[] allObstacles;
    public GameObject[] barriers;

    public Vector2 positionRange;
    public GameObject obstaclesGroup;

    private Transform Snake;
    public GameManager gameManager;
    void Start()
    {
        Snake = FindObjectOfType<SnakeTail>().transform;
        SetObstacles();
    }
    private void SetObstacles() 
    {
        for (int i = 0; i < allObstacles.Length; i++)
        {
            bool randomBool = Random.value > 0.3f;
            allObstacles[i].SetAmount(randomBool);
        }
        for (int i = 0; i < barriers.Length; i++)
        {
            bool randomBool = Random.value > 0.5f;
            barriers[i].SetActive(randomBool);
        }
    }
    private void Reposition() 
    {
        int obstaclesAmount = FindObjectsOfType<Obstacles>().Length;

        transform.position = new Vector2(0, Snake.position.y + (gameManager.ObstaclesDistance * (obstaclesAmount - 1)));
        obstaclesGroup.transform.localPosition = new Vector2(0, Random.Range(positionRange.x,positionRange.y));
    }

    private void DecreaseDifficulty() 
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            Debug.Log("Работает");
            Reposition();

            SetObstacles();
        }
    }

    void Update()
    {
        
    }
}
