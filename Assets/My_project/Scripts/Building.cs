using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // разделение плоскости на блоки равные 1 и 1.
    public Vector2Int Size = Vector2Int.one;
    public Vector3Int postion = new Vector3Int(0, 0 ,0);
    // переменная отвечающая за цвет посторойки, возможность ее постfвить на плоскость: красный и зеленый.
    public Renderer MainRenderer;
    // смена цвета
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
    // Уничтожаем Empty, в котором хранятся простройка и триггер
    int Destroy()
    {
        int i = 0;
        Destroy(gameObject);
        return i;
    }
    // Проверяем, если постройку сломали, то перемещаем Empty в начало координат(под карту), чтобы Триггер врагов
    // перестал работать.
    private void Update()
    {
        if(MainRenderer == null)
        {
            transform.position = Vector3.zero;
            Invoke("Destroy", 1f);
        }
    }
    // возвращение цвета
    public void SetNormalColor()
    {
        MainRenderer.material.color = Color.white;
    }
    // рисование зоны построек. Зона не позволит другим постройкам поставить поверх существующей. Не успел реализовать. >=(
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
