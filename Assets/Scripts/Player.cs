using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("玩家血量")]
    public int maxHp = 100;
    public int hp;

    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            GameManager.Instance.currentState = GameManager.GameState.GameOver;
            Debug.Log("玩家死亡，游戏结束");
        }
    }
}