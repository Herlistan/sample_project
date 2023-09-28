using UnityEngine;

public class Collision_building : MonoBehaviour
{
    public int health = 1000;
    float invoke_delay = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        InvokeRepeating("Damage", invoke_delay, invoke_delay);
    }
    void Damage()
    {
        health -= 5;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
