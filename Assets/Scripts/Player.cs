using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public Transform shootPoint;
    public GameObject boomPrefab;
    public Transform boomPoint;
    
    public float speed = 5;
    public Animator ani;

    public float delta = 0;
    public float span = 0.1f;
    public float boomDelta = 0;
    public float boomSpan = 9f;
    
    void Update()
    {
        Move();
        Shoot();
        Reload();
        Boom();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(x, y).normalized;
        
        ani.SetInteger("Turn", Convert.ToInt32(x));
        
        this.transform.Translate(movement * speed * Time.deltaTime);
        
        float clampX = Mathf.Clamp(this.transform.position.x, -2.3f, 2.3f);
        float clampY = Mathf.Clamp(this.transform.position.y, -4.5f, 4.5f);
        this.transform.position = new Vector2(clampX, clampY);
    }

    public void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (delta < span)
                return;
            Instantiate(playerBulletPrefab, shootPoint.position, shootPoint.rotation);
            //delta = 0;
        }

        delta = 0;
    }

    public void Boom()
    {
        if (boomSpan == 9)
        {
            boomSpan = 0;
        }
        
        if (!Input.GetKeyDown(KeyCode.B))
            return;

        if (boomDelta <= boomSpan)
            return;
        
        Instantiate(boomPrefab, boomPoint.position, boomPoint.rotation);

        if (boomSpan == 0)
        {
            boomSpan = 10;
        }

        boomDelta = 0;
    }

    public void Reload()
    {
        delta += Time.deltaTime;
        boomDelta += Time.deltaTime;
        
        Debug.Log($"폭탄 준비중... {boomDelta.ToString("F1")}s");
    }
}
