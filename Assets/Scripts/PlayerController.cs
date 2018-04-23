using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerIdle()
    {
        anim.SetBool("Walking", false);
        anim.SetBool("Shooting", false);
    }

    public void PlayerWalk ()
    {
        anim.SetBool("Walking", true);
    }

    public void PlayerShoot()
    {
        anim.SetBool("Shooting", true);
    }

}

