using UnityEngine;

public class Falling_stone : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ObjectToSpawn = GameObject.FindGameObjectWithTag("Respawn");
            GameObject obj = Instantiate(ObjectToSpawn, transform.position, transform.rotation) as GameObject;
        }
    }
}
