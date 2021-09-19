using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private bool start = false;   //нужен для начала игры и скролла камеры вниз
    public Transform target;
    public float smoothSpeed = 0.125f;

    private float minX, maxX;
    private float widthCam;

    [SerializeField] private GameObject wallL = null;
    [SerializeField] private GameObject wallR = null;

    void Start()
    {
        minX = 0 - GetWidthCam(); // левый край  (отнимаем от центра половину ширины)
        maxX = 0 + GetWidthCam(); // правый край (прибавляем к центру половину ширины)

        //расставляем стены по краям телефона
        var position = wallL.transform.position;
        position.x = minX;
        wallL.transform.position = position;

        position = wallR.transform.position;
        position.x = maxX;
        wallR.transform.position = position;
    }

    public float GetWidthCam()  //возвращает ширину камеры
    {
        widthCam = GetComponent<Camera>().orthographicSize * GetComponent<Camera>().aspect; // Получаем половину ширины камеры, путем умножения высоты на соотношение
        return widthCam;
    }

    public void StartGame()
    {
        start = true;
    }

    private void LateUpdate()
    {
        if (start)  //при старте игры следует по оси у за игроком
        {
            if (target.position.y != transform.position.y - 1.72)
            {
                Vector3 newPosition = new Vector3(transform.position.x, target.position.y + 2f, transform.position.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }
        }

    }
}
