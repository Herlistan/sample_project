using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScript_enemy : MonoBehaviour
{
    public GameObject EnemyToSpawn;
    public float speed = 0.01f;
    public GameObject baza;
    public GameObject[] spot;
    public GameObject[] spot2;
    public GameObject[] spot3;
    public GameObject[] spot4;
    public Vector3 target;
    public int healthEnemy;
    private bool flag_spot = true;
    private int CurrentHealth;
    public float delay = 0.9f;
    float timer = 1.5f;
    public int SpotSpawnNumber = 0;
    float spawn = 0;
    float delay_spawn = 2.9f;
    bool Enemycoll;
    public bool script;
    bool flag = true;
    bool Enemydamage;
    private Animator anim;

    void Start()
    {
        script = false;
        Enemycoll = false;
        Enemydamage = false;
        anim = GetComponent<Animator>();
        spot = GameObject.FindGameObjectsWithTag("Spot1");
        spot2 = GameObject.FindGameObjectsWithTag("Spot2");
        spot3 = GameObject.FindGameObjectsWithTag("Spot3");
        spot4 = GameObject.FindGameObjectsWithTag("Spot4");
        baza = GameObject.FindGameObjectWithTag("Finish");
        EnemyToSpawn = this.gameObject;
    }
    private int Dead()
    {
        Destroy(gameObject);
        return CurrentHealth;
    }
    private int Waiting()
    {
        Enemydamage = false;
        anim.SetBool("isDamage", false);
        return CurrentHealth;
    }
    void Update()
    {
        CurrentHealth = healthEnemy;
        if (spawn > delay_spawn)
        {
            // если остается 5 ХП, то враг на время останавливается, приостанавливаются текущие анимации
            // и запускается анимация получения урона
            if (healthEnemy == 5 && flag == true) 
            {
                flag = false;
                Enemydamage = true;
                anim.SetBool("isWalk", false);
                anim.SetBool("isDamage", true);
                Invoke("Waiting", 1.2f);
                timer = 0;
            }
            // если нету жизней, то враг останавливается и запускается анимация смерти и труп исчезает через 30 сек
            if (CurrentHealth == 0)
            {
                Enemydamage = true;
                anim.SetBool("isWalk", false);
                anim.SetBool("isDamage", false);
                anim.SetBool("isAttack", false);
                anim.SetBool("isDead", true);
                this.EnemyToSpawn.tag = "Dead";
                Invoke("Dead", 30f);
            }
            // условие движения
            if (EnemyToSpawn != null && Enemydamage == false && script == false)
            {
                transform.LookAt(new Vector3(target.x, target.y, target.z));
                EnemyToSpawn.transform.position = Vector3.MoveTowards(EnemyToSpawn.transform.position, target, speed);
                anim.SetBool("isWalk", true);
                if (Vector3.Distance(EnemyToSpawn.transform.position, baza.transform.position) < 2)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            // Выбор маршрута. Зависит от места спавна
            if (SpotSpawnNumber == 1)
            {
                if (flag_spot == true)
                {
                    flag_spot= false;
                    target = spot[0].transform.position;
                }
                if (Vector3.Distance(EnemyToSpawn.transform.position, spot[0].transform.position) < 2)
                {
                    target = spot[1].transform.position;
                }
                if (Vector3.Distance(EnemyToSpawn.transform.position, spot[1].transform.position) < 2)
                {
                    target = baza.transform.position;
                }
            }
            if (SpotSpawnNumber == 2)
            {
                if (flag_spot == true)
                {
                    flag_spot = false;
                    target = spot2[0].transform.position;
                }
                if (Vector3.Distance(EnemyToSpawn.transform.position, spot2[0].transform.position) < 2)
                {
                    target = spot2[1].transform.position;
                }
                if (Vector3.Distance(EnemyToSpawn.transform.position, spot2[1].transform.position) < 2)
                {
                    target = baza.transform.position;
                }
            }
            if (SpotSpawnNumber == 3)
            {
                if (flag_spot == true)
                {
                    flag_spot = false;
                    target = spot3[0].transform.position;
                }
                if (Vector3.Distance(EnemyToSpawn.transform.position, spot3[0].transform.position) < 2)
                {
                    target = spot3[1].transform.position;
                }
                if (Vector3.Distance(EnemyToSpawn.transform.position, spot3[1].transform.position) < 2)
                {
                    target = baza.transform.position;
                }
            }
            if (SpotSpawnNumber == 4)
            {
                if (flag_spot == true)
                {
                    flag_spot = false;
                    target = spot4[0].transform.position;
                }
                if (Vector3.Distance(EnemyToSpawn.transform.position, spot4[0].transform.position) < 2)
                {
                    target = spot4[1].transform.position;
                }
                if (Vector3.Distance(EnemyToSpawn.transform.position, spot4[1].transform.position) < 2)
                {
                    target = baza.transform.position;
                }
            }
        }
        spawn += Time.deltaTime;
    }
}
