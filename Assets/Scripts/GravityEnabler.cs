using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEnabler : MonoBehaviour
{
    [Header("Assign all cubes that need gravity")]
    [SerializeField] private GameObject[] cubes;

    public void EnableGravity()
    {
        foreach (GameObject cube in cubes)
        {
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false; // just in case it was set
            }
        }
    }
}
