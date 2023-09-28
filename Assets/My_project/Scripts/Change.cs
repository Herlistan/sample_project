using UnityEngine;

public class Change : MonoBehaviour
{
    [SerializeField] private MeshFilter WhatToChange;
    [SerializeField] private Mesh[] WhatExactlyToChange;
    public int numtool;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            numtool = Random.Range(0, WhatExactlyToChange.Length);
            WhatToChange.mesh = WhatExactlyToChange[numtool];
        }
    }
}
