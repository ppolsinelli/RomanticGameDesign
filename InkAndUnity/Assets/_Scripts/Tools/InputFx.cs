using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RD
{
    public class InputFx : MonoBehaviour
{

        public ParticleSystem particleKnock;

        public void KnockPlay()
        {

            var mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //Debug.Log(mousePos);

            particleKnock.transform.position = mousePos;
            particleKnock.Play();

        }
        
    }

}
