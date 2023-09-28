using UnityEngine;
using UnityEngine.UI;

public class Click_Object : MonoBehaviour
{
    private Text textToEdit;
    void Start()
    {
        textToEdit = GetComponent<Text>();
    }
    public void ChangeText()
    {
        textToEdit.text = "New Text";
    }
}
