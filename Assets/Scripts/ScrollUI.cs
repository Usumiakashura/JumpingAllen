using UnityEngine;

public class ScrollUI : MonoBehaviour
{
    public float speed = 5f, checkPos = 0f;
    private RectTransform rec;
    public bool onWindow;

    private void Start()
    {
        rec = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (onWindow)
        {
            if ((rec.offsetMin.y <= checkPos && speed > 0) ||
            (rec.offsetMin.y >= checkPos && speed < 0))
            {
                rec.offsetMin += new Vector2(rec.offsetMin.x, speed);
                rec.offsetMax += new Vector2(rec.offsetMax.x, speed);
            }
        }
    }
}
