using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCorpse : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("kill", 3f);
        rb.AddForce(new Vector2(Random.Range(-50, 50), Random.Range(-50, 50)));
    }

    // Update is called once per frame
    void kill()
    {
        Destroy(this.gameObject);
    }
}
