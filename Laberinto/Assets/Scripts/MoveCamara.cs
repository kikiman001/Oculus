using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamara : MonoBehaviour
{
    public Transform camaraPosition;
    // Update is called once per frame
    void Update()
    {
        transform.position = camaraPosition.position;
    }
}
