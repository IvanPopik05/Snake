using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Scrolling : MonoBehaviour
{
    public float speed;
    private Transform m_Transform;
    public float m_Size;
    public float m_Pos;
    private Transform cameraTransform;
    public float ParalaxSpeed;

    private void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Size = GetComponent<SpriteRenderer>().bounds.size.y;
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        cameraTransform = Camera.main.transform;
        if (cameraTransform.transform.position.y > m_Transform.position.y) 
        {
            Debug.Log("Работает движение");
            Move();
        }
    }
    public void Move() 
    {
        m_Pos -= speed * Time.deltaTime;
        m_Transform.position = new Vector3(0, m_Pos, 0);
    }

}
