using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public ParticleSystem red;
    public ParticleSystem blue;
    public ParticleSystem green;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            red.Play();
            blue.Play();
            green.Play();
        }
    }
}
