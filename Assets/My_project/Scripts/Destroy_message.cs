using System.Collections;
using UnityEngine;

public class Destroy_message : MonoBehaviour
{
    void Start()
    {
        StartCoroutine((string)Destroy());
    }

    IEnumerable Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
