using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    // Start is called before the first frame update
    public float blinkInterval = 0.5f; // The interval between each blink
    private Text text; // The Text component we want to blink

    void Start()
    {
        text = GetComponent<Text>(); // Get the Text component on this object
        if (text == null)
        {
            Debug.LogError(
                "Blinking script requires a Text component to be attached to the same GameObject."
            );
            return;
        }
        //text = GetComponent<Text>(); // Get the Text component on this object
        StartCoroutine(Blink()); // Start the blinking coroutine
    }

    IEnumerator Blink()
    {
        while (true) // Loop forever
        {
            text.enabled = !text.enabled; // Toggle the Text component on and off
            yield return new WaitForSeconds(blinkInterval); // Wait for the blink interval
        }
    }
}
