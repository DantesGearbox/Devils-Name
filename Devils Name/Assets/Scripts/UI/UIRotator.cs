using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotator : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 90f * Time.deltaTime));
    }
}
