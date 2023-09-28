using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] GameObject Text;
    void Start()
    {
        Text.SetActive(false);
    }
    public void OnMouseEnter()
    {
        Text.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
    }
    public void OnMouseExit()
    {
        Text.SetActive(false);
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
