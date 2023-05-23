using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    private ScoreManager scoring;

    // Start is called before the first frame update
    void Start()
    {
        scoring = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        InvokeRepeating("addAndUpadteScore", 6.0f, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rg = GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(-1, 0) * 3.0f;
        Destroy(this.gameObject, 10.0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            SceneManager.LoadScene("ScoreDisplay");
        }
    }

    private void addAndUpadteScore()
    {
        scoring.AddScore(1);
    }
}
