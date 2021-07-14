using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Obstacle : MonoBehaviour
{
    public TMP_Text amountText;
    public int amount;
    public GameManager gameManager;
    public SnakeTail snakeTail;
    public GameObject EffectPrefab;
    public SpriteRenderer sprite;
    private AudioSource audioSource;
    public float t;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        EffectPrefab.SetActive(false);
    }
    private void Update()
    {
    }
    public void SetAmount(bool randomBool) 
    {
        gameObject.SetActive(randomBool);
        amount = Random.Range(0, gameManager.maxAmountBlock);
        SetColor(sprite);
        SetAmountText();
    }
    private void SetAmountText() 
    {
        amountText.text = amount.ToString();
    }
    public void SetColor(SpriteRenderer spriteRenderer) 
    {
        float PlayerLives = snakeTail.XP;
        Color newColor;
            if (amount > PlayerLives * 1.2f)
            {
                newColor = gameManager.ImpossiblyColor;
            }
            else if (amount >= PlayerLives / 1.2f)
            {
                newColor = gameManager.HardColor;
            }
            else if (amount >= PlayerLives / 1.5f)
            {
                newColor = gameManager.MiddleColor;
            }
            else
            {
                newColor = gameManager.EasyColor;
            }
            spriteRenderer.color = newColor;
    }

    public void SnakeDamage() 
    {
        SetAmountText();
        if (amount < 0)
        {
            gameObject.SetActive(false);
            EffectPrefab.SetActive(false);
        }
        else if (amount > 0)
        {
            StartCoroutine(DamageEffect());
        }
    }
    IEnumerator DamageEffect() 
    {
        float timer = 0;
        while (timer < gameManager.damageTime)
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0.2f);
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        t -= Time.deltaTime;
        if (col.gameObject.CompareTag("Player")) 
        {
            if (t < 0)
                {
                if (snakeTail.XP <= 1) 
                {
                    this.gameManager.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                    
                    gameManager.SetAmountObstacles();
                    gameManager.amountObstacles += 1;
                    snakeTail.RemoveCircle();
                    snakeTail.XP--;
                    amount--;
                    audioSource.Play();
                    EffectPrefab.SetActive(true);
                    SnakeDamage();
                    t = 0.3f;
                }
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            EffectPrefab.SetActive(false);
        }
    }
}
