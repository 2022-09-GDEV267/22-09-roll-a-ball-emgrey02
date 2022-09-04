using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // called every frame
    void Update()
    {
        transform.Rotate(new Vector3(35, 20, 80) * Time.deltaTime);
    }
}
