using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroingParticle : MonoBehaviour
{
    private void Update()
    {
        Invoke("Destroing", 1);
    }
    private void Destroing()
    {
        Destroy(gameObject);
    }
}
