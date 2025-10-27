using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int hp;
    public Sprite[] sprite;
    public SpriteRenderer spriteRenderer;
    public Coroutine coroutine;

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            StartCoroutine(ChangeSprite());
            if(coroutine != null)
                StopCoroutine(ChangeSprite());
            
            hp--;
            Debug.Log($"적의 hp:{hp}");
            if (hp <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("적이 격추됨");
            }   
        }
    }

    IEnumerator ChangeSprite()
    {
        spriteRenderer.sprite = sprite[1];
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = sprite[0];
    }
}
