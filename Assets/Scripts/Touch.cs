using UnityEngine;

public class Touch : MonoBehaviour
{
    public int Touches { get; set; }

    private void Start()
    {
        if (RestartGame.Restart) gameObject.GetComponent<StartGame>().SG();
    }
    
    private void OnMouseDown()
    {
        if (RestartGame.Restart)
            Touches++;
        else
        {
            RestartGame.Restart = true;
            gameObject.GetComponent<StartGame>().SG();
        }
    }

}
