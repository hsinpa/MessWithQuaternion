using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hsinpa.Rotation
{
    public class RotationClient : MonoBehaviour
    {
        Quaternion rotR, rotU;

        [SerializeField]
        private float rotation_speed = 10;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.rotR = Quaternion.AngleAxis(rotation_speed * Time.deltaTime, Vector3.right);
            this.rotU = Quaternion.AngleAxis(rotation_speed * Time.deltaTime, Vector3.up);

            // rotate around World Right
            transform.rotation = transform.rotation * Quaternion.identity;

            // rotate around Local Up
            transform.rotation = transform.rotation * (this.rotU * this.rotR).normalized;

        }
    }
}
