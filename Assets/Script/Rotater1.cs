using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater1 : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
