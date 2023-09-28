using UnityEngine;

public class Tower_shoot : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject enemy;
    public float distance;
    int HealthEnemy = 0;
    public float delay = 3;
    float timer = 0;
    int i = 0;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    int ColorBasicDamage()
    {
        return i;
    }
    int Damage()
    {
        HealthEnemy -= 5;
        timer = 0;
        Invoke("ColorBasicDamage", 1f);
        enemy.GetComponent<MoveScript_enemy>().healthEnemy = HealthEnemy;
        return HealthEnemy;
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy == null || enemy.tag == "Dead")
        {
            enemy = enemies[0];
        }
        if(enemies.Length > 1)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < distance)
            {
                if(timer > delay)
                {
                    HealthEnemy = enemy.GetComponent<MoveScript_enemy>().healthEnemy;
                    Damage();
                }
                timer += Time.deltaTime;
            }
            else
            {
                if (i >= enemies.Length - 1) i = 0;
                i++;
                enemy = enemies[i];
            }
        }
        
    }
}
