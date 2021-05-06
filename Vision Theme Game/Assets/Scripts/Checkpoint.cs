using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    float CPX;
    float CPY;
    float CPZ;
    // Start is called before the first frame update

    void CPsetX(float checkX)
    {
        CPX = checkX;
    }
    void CPsetY(float checkY)
    {
        CPY = checkY;
    }
    void CPsetZ(float checkZ)
    {
        CPZ = checkZ;
    }
    void gotoCP()
    {
        transform.position = new Vector3(CPX, CPY , CPZ);
    }
}
