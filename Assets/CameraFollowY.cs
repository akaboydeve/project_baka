using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowY : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float CamPos = 0;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    public Rigidbody2D PlayerRB;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y + CamPos, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x, playerPosition.y + offset, playerPosition.z);
        }
        else
        {

            playerPosition = new Vector3(playerPosition.x, playerPosition.y - offset, playerPosition.z);

        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        // Debug.Log(player.transform.localScale.x);
        // Debug.Log(PlayerRB.velocity.y);
    }
}