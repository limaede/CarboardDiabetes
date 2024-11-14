using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giroscope : MonoBehaviour
{
    public GameObject VRcameras;

    private float startPositionY = 0f;
    private float giroscopeYPos = 0f;
    float calibrateToYPos = 0f;
    public bool gameStart;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        startPositionY = VRcameras.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGyroscopeRotation();
        //ApplyGAyroscopeRotation();
        ApplyCalibration();
        if (gameStart)
        {
            Invoke("CalibrateToYPos", 3f);
            gameStart = false;
        }
    }
    void ApplyGyroscopeRotation()
    {
        // Captura la rotaci�n del giroscopio
        Quaternion deviceRotation = Input.gyro.attitude;

        // Convierte la rotaci�n para que se adapte a la orientaci�n de la c�mara
        // y solo considera el movimiento en el eje Y
        //deviceRotation = Quaternion.Euler(deviceRotation.x, deviceRotation.eulerAngles.y, -deviceRotation.z);
        deviceRotation = Quaternion.Euler(90f, 0f, 180f) * new Quaternion(deviceRotation.x, deviceRotation.y, -deviceRotation.z, -deviceRotation.w);

        // Aplica la rotaci�n relativa en el eje Y
        VRcameras.transform.localRotation = deviceRotation;

        // Guarda la posici�n en el eje Y para futuras calibraciones
        giroscopeYPos = VRcameras.transform.eulerAngles.y;
    }
    void ApplyGAyroscopeRotation()
    {
        VRcameras.transform.rotation = Input.gyro.attitude;
        VRcameras.transform.Rotate(0f, 0f, 0f, Space.Self);
        VRcameras.transform.Rotate(0f, 0f, 0f, Space.World);
        giroscopeYPos = VRcameras.transform.eulerAngles.z;
    }
    void CalibrateToYPos()
    {
        calibrateToYPos = giroscopeYPos - startPositionY;
    }
    void ApplyCalibration()
    {
        VRcameras.transform.Rotate(0f, -calibrateToYPos, 0f, Space.World);
    }
}
