using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    // 场景边界
    public float xMin = -20;
    public float xMax = 3;
    public float yMin = -11;
    public float yMax = -2;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 moveDir = new Vector2(h, v).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        // ====== 边界限制 ======
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, xMin, xMax);
        pos.y = Mathf.Clamp(pos.y, yMin, yMax);
        transform.position = pos;
    }
}