using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    public ParticleSystem Fire;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Fire.Play();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Fire.Emit(Random.Range(3, 16));
        }
    }
}
