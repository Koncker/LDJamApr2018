using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {

    public GameObject player;
    public Rigidbody2D rgbp;
    public PlayerController playeranimation;
    public GameObject SceneText;
    public bool insidehouse;
    public bool sarahtime;
    public GameObject scenebg;
    public GameObject scenebg2;
    public GameObject neils;
    public GameObject sarah;

    private void Start()
    {
        rgbp = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        playeranimation.PlayerIdle();
        rgbp.velocity = new Vector2(0, 0);
        if (insidehouse)
        {
            scenebg.SetActive(false);
            scenebg2.SetActive(false);
            neils.SetActive(true);
        }

        if (sarahtime)
        {
            sarah.SetActive(true);
        }

        SceneText.SetActive(true);
        Destroy(gameObject);
    }

}
