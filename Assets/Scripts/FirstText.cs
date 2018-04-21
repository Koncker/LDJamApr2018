using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstText : MonoBehaviour {

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public GameObject Text;
    public AudioSource gunshot;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            gunshot.Play();
            /* Destroy(Text); */
        }
    }

    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

}
