using UnityEngine;

public class Rotate_building : MonoBehaviour
{
    private Building flyingBiulds;

    public void StartPlacingBuilds(Building buildingPrefab)
    {
        flyingBiulds = Instantiate(buildingPrefab);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            flyingBiulds.transform.Rotate(0, 90, 0, Space.World);
        }
    }
}
