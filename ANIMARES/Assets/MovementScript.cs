using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript1 : MonoBehaviour
{
    public Animator transition;

    public GameObject sphere;

    // Update is called once per frame
    public void Move()
    {
        transition.SetTrigger("Start");
    }

    public void OffMove()
    {
        sphere.GetComponent<Rotate>().enabled = false;
    }
}
