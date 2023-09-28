using UnityEngine;

public class Pause_play : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }
    public void PlayButtonPressed()
    {
        Time.timeScale = 1f;
    }
}
