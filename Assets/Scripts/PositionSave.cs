using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSave : MonoBehaviour
{
    public float posX;
    public float posY=1f;
    public float posZ;

    public string checkpoint;

    public Vector3 Posicion;


    // Start is called before the first frame update
    void Start()
    {
        CargarPos();
    }

    // Update is called once per frame
    void Update()
    {
       checkpoint = PlayerPrefs.GetString("Collider");
    }

    public void GuardarPos()
    {
       PlayerPrefs.SetFloat("PosicionX", transform.position.x);
       PlayerPrefs.SetFloat("PosicionY", transform.position.y);
       PlayerPrefs.SetFloat("PosicionZ", transform.position.z);


    }

    public void CargarPos()
    {
       posX = PlayerPrefs.GetFloat("PosicionX");
       posY = PlayerPrefs.GetFloat("PosicionY");
       posZ = PlayerPrefs.GetFloat("PosicionZ");

       Posicion.x = posX;
       Posicion.y = posY;
       Posicion.z = posZ;

       transform.position = Posicion;

        checkpoint = PlayerPrefs.GetString("Collider");

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "checkpoint")
        {
           PlayerPrefs.SetString("Collider", other.gameObject.name);
           GuardarPos();
           //Debug.Log("DatosGuardados");
        }
    }
}
