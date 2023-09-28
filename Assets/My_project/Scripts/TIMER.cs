using UnityEngine.UI;
using UnityEngine;

public class TIMER : MonoBehaviour
{
    public float t = 90;
    public float timeMin = 0;
    public Text textToEdit;
    public float count = 1;
    void Start()
    {
        textToEdit = GetComponentInChildren<Text>();
    }
    void Update()
    {
        if(count <= 4)
        {
            t = t - Time.deltaTime;
            textToEdit.text = (t.ToString());
            if (t <= timeMin)
            {
                t = 90;
                count++;
            }
        }
        if(count > 4)
        {
            textToEdit.text = "0";
        }
        
    }
}
