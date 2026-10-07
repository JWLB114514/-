using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    // 保存原始缩放大小
    private Vector3 originalScale;

    void Start()
    {
        // 游戏启动时读取你当前的scale
        originalScale = transform.localScale;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h < 0)
        {
            // 向右：使用原始X
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (h > 0)
        {
            // 向左：X取负数，镜像，Y Z不变
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }
}