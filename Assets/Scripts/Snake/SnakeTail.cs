using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeTail : MonoBehaviour
{
    public float XP;
    public bool animActive;

    public float CircleDiameter; // Диаметр туловища
    public TMP_Text textTMP;
    public Transform SnakeHead;
    public Animator anim;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();
    void Start()
    {
        positions.Add(SnakeHead.position); // Добавление головы в массив
        if(animActive) anim.enabled = false;
        for (int i = 0; i < XP-1; i++) AddCircle();
        Time.timeScale = 1f;
    }
    void Update()
    {
        textTMP.text = XP.ToString();
        if (XP <= 1) 
        {
            XP = 0;
            this.gameObject.SetActive(false);
            Time.timeScale = 0f;
            Debug.LogError("Игра закончена");
        }
        float distance = ((Vector2)SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            // Направление от старого положения головы, к новому
            Vector2 direction = ((Vector2)SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle() 
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform); // Создание туловища
        snakeCircles.Add(circle); // Добавление туловища в Transform
        positions.Add(circle.position); // Добавление туловища в позицию
    }
    public void RemoveCircle()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(0);
        if(animActive) anim.enabled = true;
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (animActive)
            {
                anim.enabled = false;
                anim.Rebind();
            }
        }
    }
}
