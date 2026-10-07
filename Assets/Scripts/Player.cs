using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp = 3;
    public float invincibleTime = 0.5f;

    private int currentHp;
    private bool isInvincible;
    private float invincibleTimer;

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        // 无敌倒计时
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    // 受伤函数，怪物碰撞时调用
    public void TakeDamage()
    {
        if (isInvincible) return;

        currentHp--;
        Debug.Log("玩家受伤！剩余血量：" + currentHp);

        // 开启无敌
        isInvincible = true;
        invincibleTimer = invincibleTime;

        // 受伤闪烁效果（可选，观感更好）
        StartCoroutine(HurtFlash());

        if (currentHp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("游戏结束！");
        // 这里可以：暂停游戏、弹出UI、关闭玩家输入
        Time.timeScale = 0;
    }

    // 闪烁协程：无敌期间图片半透明闪烁
    System.Collections.IEnumerator HurtFlash()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        float t = 0;
        while (t < invincibleTime)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.08f);
            t += 0.08f;
        }
        sr.enabled = true;
    }
}