using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev1End : MonoBehaviour
{
    public GameObject Lev1endScreen;

    public GameObject player;
    public GameObject PlayAgainButton;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Lev1endScreen.SetActive(true);
            // PlayAgainButton.SetActive(true);
            // player.SetActive(false);
        }
    }
}
