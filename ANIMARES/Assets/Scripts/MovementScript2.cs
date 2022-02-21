using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript2 : MonoBehaviour
{
    public Animator transition;
    public Animator transition2;

    public GameObject sphere2;

    // Update is called once per frame
    public void Move()
    {
        transition.SetTrigger("Start");
        transition2.SetTrigger("Start");
    }

    public void OffMove()
    {
        sphere2.GetComponent<Rotate>().enabled = false;
    }
}
