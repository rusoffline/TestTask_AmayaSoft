using UnityEngine;

public class ParticleEffect : MonoBehaviour, IParticleEffect
{
    [SerializeField]
    private ParticleSystem particle;

    public void PlayAt(Vector3 position)
    {
        particle.transform.position = position;
        particle.Stop();
        particle.Play();
    }
}
