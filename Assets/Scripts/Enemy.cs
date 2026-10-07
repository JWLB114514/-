using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("怪物属性")]
    public float speed = 2f;
    public int hp = 40;
    public int damage = 10;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (GameManager.Instance.currentState != GameManager.GameState.Playing) return;

        //自动寻路向玩家移动
        Vector2 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    //受伤
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage();
            }
        }
    }
}
