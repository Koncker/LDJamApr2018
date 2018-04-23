using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstText : MonoBehaviour {

    public GameObject player;
    public Rigidbody2D rgbp;
    public float delay = 0.1f;
    public float walktime = 3f;
    public string fullText;
    private string currentText = "";
    public GameObject Text;
    public GameObject textnext;
    public AudioSource gunshot;
    public Text textrender;
    public PlayerController playeranimation;
    public GameObject blood;
    public GameObject dog;
    public bool canshoot;
    public bool shouldwalk;
    public bool shootneils;
    private bool neilsshot;
    public bool shootsarah;
    private bool sarahshot;
    public GameObject neilsnotshot;
    public GameObject spacebarpress;
    public GameObject backspacepress;
    public GameObject startscreen;
    public GameObject neils;
    public GameObject sarah;
    public GameObject EndGame1;
    public GameObject EndGame2;
    public GameObject EndGame3;
    public bool playgunshot;
    public GameObject anykeytostart;

    private void Start()
    {
        StartCoroutine(ShowText());
        rgbp = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (canshoot)
            {
                playeranimation.PlayerShoot();
                gunshot.Play();
                Debug.Log("Gunshot sound played");
                blood.SetActive(true);
                StartCoroutine(WaitForShoot());
            }

            if (shootneils)
            {
                playeranimation.PlayerShoot();
                gunshot.Play();
                Debug.Log("Gunshot sound played");
                blood.SetActive(true);
                StartCoroutine(WaitForShoot());
                Debug.Log("Waiting for Shoot");
                neilsshot = true;
                neils.SetActive(false);
            }

            if (neilsshot)
            {
                Destroy(spacebarpress);
                Destroy(backspacepress);
                StartCoroutine(WaitForDestroy());
                textrender.enabled = false;
                Debug.Log("Waiting for seconds");
                Debug.Log("Neils has been Shot");
            }

            if (shootsarah)
            {
                playeranimation.PlayerShoot();
                gunshot.Play();
                Debug.Log("Gunshot sound played");
                blood.SetActive(true);
                StartCoroutine(WaitForShoot());
                Debug.Log("Sarah has been shot");
                sarahshot = true;
                sarah.SetActive(false);
                player.SetActive(false);
            }

            if (sarahshot)
            {
                startscreen.SetActive(true);
                Destroy(spacebarpress);
                Destroy(backspacepress);
                StartCoroutine(WaitForDestroy());
                textrender.enabled = false;
                Debug.Log("Waiting for seconds");
                Destroy(Text);
                EndGame3.SetActive(true);
                anykeytostart.SetActive(false);
            }

            Destroy(spacebarpress);
            StartCoroutine(WaitForDestroy());
            textrender.enabled = false;
            Debug.Log("Waiting for seconds");
        }

        if (Input.GetKeyDown("backspace") && shootneils)
        {
            startscreen.SetActive(true);
            Destroy(spacebarpress);
            Destroy(backspacepress);
            textnext.SetActive(false);
            textrender.enabled = false;
            Debug.Log("Waiting for seconds");
            player.SetActive(false);
            EndGame1.SetActive(true);
            neils.SetActive(false);
            sarah.SetActive(false);
            player.SetActive(false);
            anykeytostart.SetActive(false);
        }

        if (Input.GetKeyDown("backspace") && shootsarah)
        {
            startscreen.SetActive(true);
            Destroy(spacebarpress);
            Destroy(backspacepress);
            StartCoroutine(WaitForDestroy());
            textrender.enabled = false;
            Debug.Log("Waiting for seconds");
            sarah.SetActive(false);
            player.SetActive(false);
            EndGame2.SetActive(true);
            anykeytostart.SetActive(false);
        }

    }

    IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(3);
        playeranimation.PlayerIdle();
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(walktime);
        if (shouldwalk) { 
            playeranimation.PlayerWalk();
            rgbp.velocity = new Vector2(10f, 0);
        }
        else
        {
            textnext.SetActive(true);
        }
        Destroy(Text);
    }

    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

        if (playgunshot)
        {
            gunshot.Play();
        }

        spacebarpress.SetActive(true);
        backspacepress.SetActive(true);


    }

}
