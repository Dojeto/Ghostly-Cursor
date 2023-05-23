using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;

    void Start()
    {
        FindObjectOfType<SoundManager>().Play("BackgroundMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneName);
            FindObjectOfType<SoundManager>().Stop("BackgroundMenu");
        }
    }
}
