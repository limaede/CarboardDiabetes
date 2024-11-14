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
        // Captura la rotación del giroscopio
        Quaternion deviceRotation = Input.gyro.attitude;

        // Convierte la rotación para que se adapte a la orientación de la cámara
        // y solo considera el movimiento en el eje Y
        //deviceRotation = Quaternion.Euler(deviceRotation.x, deviceRotation.eulerAngles.y, -deviceRotation.z);
        deviceRotation = Quaternion.Euler(90f, 0f, 180f) * new Quaternion(deviceRotation.x, deviceRotation.y, -deviceRotation.z, -deviceRotation.w);

        // Aplica la rotación relativa en el eje Y
        VRcameras.transform.localRotation = deviceRotation;

        // Guarda la posición en el eje Y para futuras calibraciones
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
