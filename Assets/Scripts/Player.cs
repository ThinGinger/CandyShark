using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 mousePos;
    Vector2 pos = new Vector2(0f, 0f);
    public float moveSpeed = 0.1f;
    public float rotSpeed = 0.4f;
    Rigidbody2D rb;

    Text UIText;
    public int score = 0;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UIText = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToMouse();
            FaceMouse();
        }
        UIText.GetComponent<ScoreDisplay>().setScore(score);
        UIText.GetComponent<ScoreDisplay>().setLives(lives);

        if(lives <= 0)
        {
            FindObjectOfType<GameManager>().gameEnd();
            Destroy(this.gameObject);
        }

    }

    private void FixedUpdate()
    {
        //apply position to the rigidbody
        rb.MovePosition(pos);
        rb.MoveRotation(transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
        }
        
    }

    private void MoveToMouse()
    {
        //get the mouse position
        mousePos = Input.mousePosition;

        //convert mousePos to from screenspace to worldspace
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //lerp postiion to the mouse position for smooth movement
        pos = Vector2.Lerp(transform.position, mousePos, moveSpeed);
    }

    private void FaceMouse()
    {
        //rotate player towards mouse
        mousePos.x = mousePos.x - pos.x;
        mousePos.y = mousePos.y - pos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), rotSpeed); // lerp rotation based on rotSpeed for smoothing
    }
}
