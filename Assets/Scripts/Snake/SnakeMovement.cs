using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float forwardSpeed = 5; // Скорость змейки вперёд
    public float Sensitivity = 10; // Чувствительность змейки
    private Camera mainCamera; // Добавление камеры
    private Rigidbody2D rigidBodyComp; // Добавление Rigidbody2D
    public Vector2 delta;
    public bool gameManageActive;
    public GameManager gameManager;

    public float sidewaysSpeed; // Боковая скорость
    public Vector2 touchLastPos; // Косание последней позиции
    void Start()
    {
        mainCamera = Camera.main; // Получение камеры
        rigidBodyComp = GetComponent<Rigidbody2D>(); // Получение RigidBody2D
    }
        
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition); // Координаты косания мыши
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0; // Боковая скорость сбрасывается при отпускании мыши
        }
        else if (Input.GetMouseButton(0)) // При зажатии мыши
        {
            delta = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos; // Получение координаты минус последняя касании позиции
            sidewaysSpeed += delta.x * Sensitivity; // Боковая скорость = координате по иксу умноженная на чувствительность
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition); // Получение последнего касания позиции
        }
    }
    private void FixedUpdate()
    {
        if (gameManageActive) 
        {
            if (gameManager.amountObstacles == 70) forwardSpeed = 7;
            if (gameManager.amountObstacles == 120) forwardSpeed = 10;
            if (gameManager.amountObstacles == 170) forwardSpeed = 12;
            if (gameManager.amountObstacles == 250) forwardSpeed = 15;
        }
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        rigidBodyComp.velocity = new Vector2(sidewaysSpeed * 5, forwardSpeed);
        sidewaysSpeed = 0;
    }
}
