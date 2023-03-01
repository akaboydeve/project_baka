using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public GameObject player;
    public float offsetX;
    public float CamPosX = 0;
    public float offsetSmoothingX;
    private Vector3 playerPositionX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPositionX = new Vector3(player.transform.position.x + CamPosX, transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPositionX = new Vector3(playerPositionX.x + offsetX, playerPositionX.y, playerPositionX.z);
        }
        else
        {
            playerPositionX = new Vector3(playerPositionX.x - offsetX, playerPositionX.y, playerPositionX.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPositionX, offsetSmoothingX * Time.deltaTime);
    }
}