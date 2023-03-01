using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offsetX;
    public float offsetY;
    public float camX = 0;
    public float camY = 0;
    public float offsetSmoothingX;
    public float offsetSmoothingY;
    private Vector3 playerPositionX;
    private Vector3 playerPositionY;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPositionX = new Vector3(player.transform.position.x + camX, 0, transform.position.z);
        playerPositionY = new Vector3(0, player.transform.position.y + camY, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPositionX = new Vector3(playerPositionX.x, playerPositionY.y, playerPositionX.z);
        }
        else
        {
            playerPositionX = new Vector3(playerPositionX.x, playerPositionY.y, playerPositionX.z);
        }

        if (player.transform.localScale.y > 0f)
        {
            playerPositionY = new Vector3(playerPositionX.x, playerPositionY.y + offsetY, playerPositionY.z);
        }
        else
        {
            playerPositionY = new Vector3(playerPositionX.x, playerPositionY.y - offsetY, playerPositionY.z);
        }

        // transform.position = Vector3.Lerp(transform.position, playerPositionX, offsetSmoothingX * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, playerPositionY, offsetSmoothingY * Time.deltaTime);
    }
}