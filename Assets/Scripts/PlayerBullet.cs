using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float shootSpeed = 1;
    void Update()
    {
        transform.Translate(Vector3.up * shootSpeed * Time.deltaTime);

        if (this.transform.position.y > 5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Debug.Log("적에게 명중");    
        }
    }
}
