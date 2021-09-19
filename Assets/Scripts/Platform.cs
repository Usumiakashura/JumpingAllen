using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject goGenerator;

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            float y = transform.position.y + 24.3f;
            transform.position = new Vector3(0, y, 0);

            goGenerator.GetComponent<GameObjectGenerator>().CatSpawn(y);
            goGenerator.GetComponent<GameObjectGenerator>().CoinSpawn(y);
        }
    }
}
