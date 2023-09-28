using UnityEngine;
using UnityEngine.UI;

public class Click_counter : MonoBehaviour
{
    public Text textToEdit;
    public int totalClicks = 0;
    void Start()
    {
        textToEdit = GetComponentInChildren<Text>();
    }
    public void ChangeText()
    {
        totalClicks += 1;
        textToEdit.text = totalClicks.ToString();
    }
}
