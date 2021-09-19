using UnityEngine;
using UnityEngine.UI;

public class GameObjectGenerator : MonoBehaviour
{
    private float min, max;
    private int score = 0;      //для отслеживания уровней 
    private int randomCat;
    private int randomCoin;

    [SerializeField] private GameObject platformPrefab = null; //платформа
    [SerializeField] private GameObject sleepCat = null; //кот ур 1
    [SerializeField] private GameObject walkCat = null;  //кот ур 2
    [SerializeField] private GameObject money = null;  //монета
    [SerializeField] private Text scoreText = null;

    void Start()
    {
        min = 0 - Camera.main.GetComponent<CameraFollow>().GetWidthCam();
        max = 0 + Camera.main.GetComponent<CameraFollow>().GetWidthCam();

        Vector3 SpawnerPosition = new Vector3();
        SpawnerPosition.x = 0;
        SpawnerPosition.y = -2.7f;

        for (int i = 0; i < 8; i++)
        {
            SpawnerPosition.y += 2.7f;
            Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);
            CatSpawn(SpawnerPosition.y);
            CoinSpawn(SpawnerPosition.y);
        }
    }


    public void CatSpawn(float y)
    {
        score = 8 + System.Convert.ToInt32(scoreText.text.Substring(7, scoreText.text.Length - 7));

        if (score > 10)
            randomCat = Random.Range(-1, 3);
        else randomCat = Random.Range(-1, 2);
        
        switch (randomCat)
        {
            case 1:
                Instantiate(sleepCat, new Vector2(Random.Range(min + 0.7f, max - 0.7f), y + 0.39f), Quaternion.identity);
                break;
            case 2:
                Instantiate(walkCat, new Vector2(Random.Range(min + 0.7f, max - 0.7f), y + 0.62f), Quaternion.identity);
                break;
        }

    }

    public void CoinSpawn(float y)
    {
        randomCoin = Random.Range(-1, 2);
        switch (randomCoin)
        {
            case 1:
                Instantiate(money, new Vector2(Random.Range(-2f, 2f), y + Random.Range(1.5f, 2f)), Quaternion.identity);
                break;
                //case 2:   //в будущем для более крупной вплюты
                //    Instantiate(diamond, new Vector2(Random.Range(min + 0.7f, max - 0.7f), catY + 0.75f), Quaternion.identity);
                //    break;
        }

    }
}
