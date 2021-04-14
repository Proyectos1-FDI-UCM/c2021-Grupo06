﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilacion : MonoBehaviour
{
    public float reposo;

    static bool enReposo;

    private float x, y, rot;

    private Transform vent;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<MelvinGrowth>() != null && Input.GetKey(KeyCode.E) && !enReposo)
        {
            if (this.gameObject.name == "1")
            {
                vent = this.gameObject.transform.parent.GetChild(1);
            }
            else if (this.gameObject.name == "2")
            {
                vent = this.gameObject.transform.parent.GetChild(0);
            }

            x = vent.transform.position.x;
            y = vent.transform.position.y;

            rot = vent.transform.eulerAngles.z;


            if (rot > 45 && rot < 135)
                other.gameObject.transform.parent.position = new Vector2(x + 1, y);
            else if (rot > 135 && rot < 225)
                other.gameObject.transform.parent.position = new Vector2(x, y + 1);
            else if (rot > 225 && rot < 315)
                other.gameObject.transform.parent.position = new Vector2(x - 1, y);
            else
                other.gameObject.transform.parent.position = new Vector2(x, y - 1);
            //Que coja el padre del other y lo mueva a la posicion de la otra -1 en y

            enReposo = true;

            Invoke(nameof(CancelReposo), reposo);

        }
    }

    void CancelReposo()
    {
        enReposo = false;
    }
}