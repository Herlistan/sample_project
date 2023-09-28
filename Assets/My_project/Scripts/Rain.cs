using UnityEngine;

public class Rain : MonoBehaviour
{
    public bool flag = true;
    public bool rain;
    public GameObject Rain_cloud;

    public void Update()
    {
        ParticleSystem Rain_cloud = GetComponent<ParticleSystem>();
        if (rain == true)
        {
            Rain_cloud.Play(rain);
        }
        else
        {
            Rain_cloud.Stop(rain);
        }
    }
}
