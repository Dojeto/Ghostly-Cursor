using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SoundManager>().Play("Background");
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (transform.position.y >= 4.5f)
        {
            Vector3 temp = transform.position;
            temp.y = 4.5f;
            transform.position = temp;
        }
        if (transform.position.y <= -4.5f)
        {
            Vector3 temp = transform.position;
            temp.y = -4.5f;
            transform.position = temp;
        }
    }

    void LateUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(0f, mousePosition.y);
        rb.velocity = direction * 2.5f;
    }
}
