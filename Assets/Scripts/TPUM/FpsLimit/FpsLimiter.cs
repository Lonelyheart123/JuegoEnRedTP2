using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLimiter : MonoBehaviour
{
    private int limit = 60;

    private void Awake()
    {
        Application.targetFrameRate = limit;
    }
}
