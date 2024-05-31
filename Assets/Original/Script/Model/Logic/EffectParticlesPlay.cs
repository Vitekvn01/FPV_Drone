using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectParticlesPlay : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particles;
    public void Play()
    {
        foreach (ParticleSystem effect in _particles)
        {
            effect.Play();
        }
    }
}
