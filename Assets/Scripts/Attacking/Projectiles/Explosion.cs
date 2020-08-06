using UnityEngine;

class Explosion : MonoBehaviour
{
    public float MaxDuration;

    private float lifetime;

    private void Start()
    {
        
    }

    private void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime > MaxDuration)
            Destroy(gameObject);
    }
}
