using UnityEngine;

public class Enemymanager : MonoBehaviour
{
    public GameObject EnemyToSpawn;
    public GameObject[] EnemysToSpawn;
    public GameObject spawn;
    public float TimetoSpawn = 90; // время до волны
    public int WaveGlobal = 0;
    public int Wave1 = 0;
    public int Wave2 = 0;
    public int Wave3 = 0; // эти 4-ре переменные передают врагам маршрут, по которому они должны идти.
    public int Wave4 = 0;
    private void Start()
    {
        spawn = this.gameObject;
    }
    void Update()
    {
        if (TimetoSpawn <= 0)
        {
            WaveGlobal++; // Волны врагов, чем больше число, тем больше врагов.
            if (spawn.tag == "Spawn1" && WaveGlobal >= 1 && WaveGlobal <= 4)
            {
                Wave1 = 1;
                EnemyToSpawn = GameObject.FindGameObjectWithTag("Enemy");
                this.EnemyToSpawn.GetComponent<MoveScript_enemy>().SpotSpawnNumber = Wave1;
                GameObject obj = Instantiate(EnemyToSpawn, transform.position, transform.rotation) as GameObject;
                obj.GetComponent<MoveScript_enemy>().enabled = true;
                EnemysToSpawn = GameObject.FindGameObjectsWithTag("Enemy");
            }
            if (spawn.tag == "Spawn2" && WaveGlobal >= 2 && WaveGlobal <= 4)
            {
                Wave2 = 2;
                EnemyToSpawn = GameObject.FindGameObjectWithTag("Enemy");
                this.EnemyToSpawn.GetComponent<MoveScript_enemy>().SpotSpawnNumber = Wave2;
                GameObject obj = Instantiate(EnemyToSpawn, transform.position, transform.rotation) as GameObject;
                obj.GetComponent<MoveScript_enemy>().enabled = true;
                EnemysToSpawn = GameObject.FindGameObjectsWithTag("Enemy");
            }
            if (spawn.tag == "Spawn3" && WaveGlobal >= 3 && WaveGlobal <= 4)
            {
                Wave3 = 3;
                EnemyToSpawn = GameObject.FindGameObjectWithTag("Enemy");
                this.EnemyToSpawn.GetComponent<MoveScript_enemy>().SpotSpawnNumber = Wave3;
                GameObject obj = Instantiate(EnemyToSpawn, transform.position, transform.rotation) as GameObject;
                obj.GetComponent<MoveScript_enemy>().enabled = true;
                EnemysToSpawn = GameObject.FindGameObjectsWithTag("Enemy");
            }
            if (spawn.tag == "Spawn4" && WaveGlobal >= 4 && WaveGlobal <= 4)
            {
                Wave4 = 4;
                EnemyToSpawn = GameObject.FindGameObjectWithTag("Enemy");
                this.EnemyToSpawn.GetComponent<MoveScript_enemy>().SpotSpawnNumber = Wave4;
                GameObject obj = Instantiate(EnemyToSpawn, transform.position, transform.rotation) as GameObject;
                obj.GetComponent<MoveScript_enemy>().enabled = true;
                EnemysToSpawn = GameObject.FindGameObjectsWithTag("Enemy");
            }
            TimetoSpawn = 90;
        }
        TimetoSpawn -= Time.deltaTime;
    }
}
