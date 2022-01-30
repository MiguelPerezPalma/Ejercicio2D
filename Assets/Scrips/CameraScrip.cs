using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrip : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion=transform.position;
        posicion.x=player.transform.position.x;
        posicion.y=player.transform.position.y;
        transform.position=posicion;
    }
}
