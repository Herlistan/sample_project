using UnityEngine;

public class Script_Enemy : MonoBehaviour
{
    private Animator anim;
    public GameObject EnemyToSpawn;
    void Start()
    {
        EnemyToSpawn = this.gameObject;
        anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Building")
        {
            anim.SetBool("isWalk", false);
            EnemyToSpawn.GetComponent<MoveScript_enemy>().script = true;
            EnemyToSpawn.transform.position = EnemyToSpawn.transform.position;
            anim.SetBool("isAttack", true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other != null)
        {
            EnemyToSpawn.GetComponent<MoveScript_enemy>().script = false;
            anim.SetBool("isAttack", false);
        }
    }
}
