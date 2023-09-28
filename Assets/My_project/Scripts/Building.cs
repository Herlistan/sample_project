using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // ���������� ��������� �� ����� ������ 1 � 1.
    public Vector2Int Size = Vector2Int.one;
    public Vector3Int postion = new Vector3Int(0, 0 ,0);
    // ���������� ���������� �� ���� ����������, ����������� �� ����f���� �� ���������: ������� � �������.
    public Renderer MainRenderer;
    // ����� �����
    public void SetTransparent(bool available)
    {
        if(available)
        {
            MainRenderer.material.color = Color.green;
        }
        else
        {
            MainRenderer.material.color = Color.red;
        }
    }
    // ���������� Empty, � ������� �������� ���������� � �������
    int Destroy()
    {
        int i = 0;
        Destroy(gameObject);
        return i;
    }
    // ���������, ���� ��������� �������, �� ���������� Empty � ������ ���������(��� �����), ����� ������� ������
    // �������� ��������.
    private void Update()
    {
        if(MainRenderer == null)
        {
            transform.position = Vector3.zero;
            Invoke("Destroy", 1f);
        }
    }
    // ����������� �����
    public void SetNormalColor()
    {
        MainRenderer.material.color = Color.white;
    }
    // ��������� ���� ��������. ���� �� �������� ������ ���������� ��������� ������ ������������. �� ����� �����������. >=(
    private void OnDrawGizmosSelected()
    {
        for(int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
                Gizmos.DrawCube(transform.position + new Vector3(x + (float)(postion.x - 0.5), (float)(postion.y), y + (float)(postion.z - 0.5)), new Vector3(1, .5f, 1));
            }
        }
    }
}
