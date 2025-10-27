using System;
using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public Animator ani;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeOut());
    }
    
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
