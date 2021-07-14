using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdditiveCircle : MonoBehaviour
{
    public TMP_Text amountText;
    public int amount;
    [Header("Prefab")]
    public GameObject additiveCircle;
    private SnakeTail snakeTail;

    void Start()
    {
        amount = Random.Range(1,20);
        amountText.text = amount.ToString();
        gameObject.SetActive(true);
        snakeTail = FindObjectOfType<SnakeTail>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            for (int i = 0; i < amount; i++)
            {
                snakeTail.AddCircle();
                snakeTail.XP++;
            }
            gameObject.SetActive(false);
        }
    }
}
