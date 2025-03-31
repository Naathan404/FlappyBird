using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private Transform mark;
    [SerializeField] private Transform firstBg;
    [SerializeField] private Transform secondBg;
    [SerializeField] private float width;
    [SerializeField] private float scrollSpeed;

    private void Update()
    {
        firstBg.position += Vector3.left * scrollSpeed * Time.deltaTime;
        secondBg.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (mark.position.x > firstBg.position.x)
            RegenerateBackgroundPosition(Vector3.right);
    }

    void RegenerateBackgroundPosition(Vector3 direction)
    {
        secondBg.position = firstBg.position + direction * width;
        Transform temp = firstBg;
        firstBg = secondBg;
        secondBg = temp;
    }
}
