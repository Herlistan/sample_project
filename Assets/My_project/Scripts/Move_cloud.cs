using UnityEngine;

public class Move_cloud : MonoBehaviour
{
    public GameObject[] resident;
    public GameObject cloud;
    public GameObject Rain_cloud;
    private Vector3 residentPosition;
    private int i = 0;
    private bool isRain = false;
    public float speed = 2f;
    public Vector3 target = new Vector3(7, 30, -15);
    Vector3 currentVelocity;

    void Start()
    {
        resident = GameObject.FindGameObjectsWithTag("Residents");
        cloud = GameObject.FindGameObjectWithTag("Cloud");
        residentPosition = target;
        isRain = true;
    }
    void Update()
    {
        cloud.transform.position = Vector3.SmoothDamp(cloud.transform.position, residentPosition, ref currentVelocity, speed);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (i < resident.Length)
            {
                residentPosition = resident[i].transform.position;
                residentPosition = new Vector3(residentPosition.x, 30, residentPosition.z);
                i++;
            }
            else
            {
                i = 0;
                residentPosition = resident[i].transform.position;
                residentPosition = new Vector3(residentPosition.x, 30, residentPosition.z);
                i++;
            }
        }
    }
    // в FixedUpdate расположено условие запуска и отключения частиц, что зависит от близости жителя.
    private void FixedUpdate()
    {
        if ((Mathf.Abs(cloud.transform.position.x - residentPosition.x) <= 1) && (Mathf.Abs(cloud.transform.position.z - residentPosition.z) <= 1))
        {
            isRain = true;
            Rain_cloud.GetComponent<Rain>().rain = isRain;
            Rain_cloud.GetComponent<Rain>().Update();
        }
        else
        {
            isRain = false;
            Rain_cloud.GetComponent<Rain>().rain = isRain;
            Rain_cloud.GetComponent<Rain>().Update();
        }
    }
}
