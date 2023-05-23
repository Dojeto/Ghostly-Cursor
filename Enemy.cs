using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public LayerMask playerLayer;
    private LineRenderer lr;
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        InvokeRepeating("SpawnLasre", 8.0f, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 tempPos = transform.position;
        tempPos.y = mousePosition.y;
        transform.position = tempPos;
        if (transform.position.y >= 4.7f)
        {
            Vector3 temp = transform.position;
            temp.y = 4.7f;
            transform.position = temp;
        }
        if (transform.position.y <= -4.7f)
        {
            Vector3 temp = transform.position;
            temp.y = -4.7f;
            transform.position = temp;
        }
        lr.SetPosition(0, transform.position);

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            lr.GetPosition(1) - transform.position,
            Mathf.Infinity,
            playerLayer
        );
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player") && lr.enabled)
        {
            Debug.Log("Line hit the player!");
            Destroy(hit.collider.gameObject);
            FindObjectOfType<SoundManager>().Stop("Beam");
            FindObjectOfType<SoundManager>().Stop("Background");
            SceneManager.LoadScene("ScoreDisplay");
        }
    }

    public void SpawnLasre()
    {
        lr.SetPosition(1, new Vector3(20, transform.position.y, 0));
        lr.enabled = true;
        FindObjectOfType<SoundManager>().Play("Beam");
        Invoke("DisableLineRenderer", 3.5f);
    }

    private void DisableLineRenderer()
    {
        lr.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
    }
}
