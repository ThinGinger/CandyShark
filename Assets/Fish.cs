using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public bool bSwimLeft = false; // false for right, true for left
    public bool isDeadly = false;
    public float moveSpeed = 3;
    private Vector2 screenBounds;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(isDeadly)
            {
                Destroy(other.gameObject);
            }
            else
            {
                //give points
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        if(bSwimLeft)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;

        }
        else
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
