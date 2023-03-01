using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevDoor : MonoBehaviour
{
    public int LevelToLoad;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(LevelToLoad);
        }
    }

}
