using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(100, 100); // Vector2Int - целоцисленное значение.
    public Building[,] grid; // [] и [,] относ€тс€ к массивам, один одномерный, другой двумерный.
    private Building flyingBiulds; // выбранна€ постройка
    private Camera mainCamera; // ќт камеры возьмем луч
    int stick;
    int wood; // стоимость построек
    int stone;
    bool flag = true; // бул нужен дл€ уведомлени€ "Ќе хватает ресурсов"
    float delay = 3; // врем€ жизни сообщени€
    float timer = 0; // отсчет времени
    GameObject counter_wood;
    GameObject counter_stick;
    GameObject counter_stone;
    GameObject message;

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];
        mainCamera = Camera.main;
        message = GameObject.FindGameObjectWithTag("Message");
        message.SetActive(false);
        counter_wood = GameObject.FindGameObjectWithTag("Wood");
        counter_stick = GameObject.FindGameObjectWithTag("Stick");
        counter_stone = GameObject.FindGameObjectWithTag("Stone");
    }

    public void StartPlacingBuilds(Building buildingPrefab)
    {
        if(flyingBiulds != null)
        {
            Destroy(flyingBiulds.gameObject);
        }
        flyingBiulds = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if(flyingBiulds != null)
        {
            flyingBiulds.gameObject.SetActive(true);

            // первое значение это нормаль плоскасти (вектор направлен вверх, но также можно написать down и суть была бы та же), второе это точка на плоскости.
            // также это бесконечна€ плоскость
            var groundPlane = new Plane(Vector3.up, Vector3.zero);

            //бесконечный луч
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // проверка пересекаетс€ ли плоскость и луч
            if(groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                //определение координат х и у.
                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);
                int y1 = Mathf.RoundToInt(worldPosition.y);

                // проверка на границы плоскости
                bool available = true;
                if (x < -100 || x > 100 || x > GridSize.x - flyingBiulds.Size.x) available = false;
                if (y < -100 || y > 100 || y > GridSize.y - flyingBiulds.Size.y) available = false;

                // эта строчка позвол€ет инциализировать здание
                flyingBiulds.transform.position = new Vector3(x, 0 , y);

                // задаем цвет при помощи вызова функции
                flyingBiulds.SetTransparent(available);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    flyingBiulds.transform.Rotate(0, 90, 0, Space.World);
                }

                // эта строчка позвол€ет зафиксировать здание на плоскости
                if (available && Input.GetMouseButtonDown(0))
                {
                    wood = counter_wood.GetComponent<Click_counter>().totalClicks;
                    stick = counter_stick.GetComponent<Click_counter>().totalClicks;
                    stone = counter_stone.GetComponent<Click_counter>().totalClicks;

                    if (flyingBiulds.tag == "Wall")
                    {
                        if (wood >= 10 && stick >= 10 && stone >= 5)
                        {
                            wood -= 10;
                            stick -= 10;
                            stone -= 5;

                            counter_wood.GetComponent<Click_counter>().textToEdit.text = wood.ToString();
                            counter_stick.GetComponent<Click_counter>().textToEdit.text = stick.ToString();
                            counter_stone.GetComponent<Click_counter>().textToEdit.text = stone.ToString();
                        }
                        else
                        {
                            Destroy(flyingBiulds.gameObject);
                            message.SetActive(true);
                            flag = false;
                            Debug.Log("Mouse is over GameObject.");
                        }
                    }
                    if (flyingBiulds.tag == "CornerWall")
                    {
                        if (wood >= 10 && stick >= 10 && stone >= 5)
                        {
                            wood -= 10;
                            stick -= 10;
                            stone -= 5;

                            counter_wood.GetComponent<Click_counter>().textToEdit.text = wood.ToString();
                            counter_stick.GetComponent<Click_counter>().textToEdit.text = stick.ToString();
                            counter_stone.GetComponent<Click_counter>().textToEdit.text = stone.ToString();
                        }
                        else
                        {
                            Destroy(flyingBiulds.gameObject);
                            message.SetActive(true);
                            flag = false;
                        }

                    }
                    if (flyingBiulds.tag == "Tower")
                    {
                        if (wood >= 40 && stick >= 30 && stone >= 20)
                        {
                            wood -= 40;
                            stick -= 30;
                            stone -= 20;

                            counter_wood.GetComponent<Click_counter>().textToEdit.text = wood.ToString();
                            counter_stick.GetComponent<Click_counter>().textToEdit.text = stick.ToString();
                            counter_stone.GetComponent<Click_counter>().textToEdit.text = stone.ToString();
                        }
                        else
                        {
                            Destroy(flyingBiulds.gameObject);
                            message.SetActive(true);
                            flag = false;
                        }
                    }
                    counter_wood.GetComponent<Click_counter>().totalClicks = wood;
                    counter_stick.GetComponent<Click_counter>().totalClicks = stick;
                    counter_stone.GetComponent<Click_counter>().totalClicks = stone;
                    // возврат цвета
                    flyingBiulds.SetNormalColor();
                    // фиксаци€ постройки
                    flyingBiulds = null;
                }
            }
        }
        //ставим таймер жизни сообщени€ об нехватки ресурсов
        if (timer < delay && flag == false)
        {
            timer += Time.deltaTime;
        }
        else
        {
            flag = true;
            timer = 0;
            message.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            wood += 1000;
            stick += 1000;
            stone += 1000;
            counter_wood.GetComponent<Click_counter>().totalClicks = wood;
            counter_stick.GetComponent<Click_counter>().totalClicks = stick;
            counter_stone.GetComponent<Click_counter>().totalClicks = stone;
            counter_wood.GetComponent<Click_counter>().textToEdit.text = wood.ToString();
            counter_stick.GetComponent<Click_counter>().textToEdit.text = stick.ToString();
            counter_stone.GetComponent<Click_counter>().textToEdit.text = stone.ToString();
        }
    }
}
