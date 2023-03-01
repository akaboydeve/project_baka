using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private GameObject currentGun;
    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    public void AddGun(GameObject gunPrefab)
    {
        // Check if the player is already carrying a gun
        if (currentGun != null)
        {
            // Destroy the current gun
            Destroy(currentGun);
        }

        // Instantiate the new gun and attach it to the player's hand
        // currentGun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
        // currentGun.transform.parent = transform;


        currentGun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
        currentGun.transform.parent = transform;
        currentGun.transform.localPosition = new Vector3(0f, 0f, 0f); // Offset the gun from the player
        currentGun.transform.localRotation = Quaternion.identity; // Set the gun rotation to be fixed

        // Set the player as the gun's owner
        currentGun.GetComponent<GunController>().SetOwner(gameObject);
    }


}
