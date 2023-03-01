using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimit : MonoBehaviour
{
    void awake()
    {
        Application.targetFrameRate = 60;
    }
}
