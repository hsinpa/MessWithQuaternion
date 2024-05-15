
using System;
using System.Security.Principal;
using System.Text;
using UnityEngine;
using static Unity.Mathematics.math;

namespace Hsinpa.Rotation {
    class HandQuaternion {
        
        public float x, y, z, w;

        public HandQuaternion(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void normalize() {
            float norm = sqrt ( (x * x) + (y * y) + (z * z) + (w * w));
            this.x = x / norm;
            this.y = y / norm;
            this.z = z / norm;
            this.w = w / norm;
        }

        #region Static Function 
        public static HandQuaternion Identity() {
            return new HandQuaternion(0, 0, 0, 1);
        }


        public static HandQuaternion Normalize(HandQuaternion quaternion) {
            float norm = sqrt ( (quaternion.x * quaternion.x) + (quaternion.y * quaternion.y) + (quaternion.z * quaternion.z) + (quaternion.w * quaternion.w));

            return new HandQuaternion(quaternion.x / norm, quaternion.y / norm, quaternion.z / norm, quaternion.w / norm);
        }

                
        public static HandQuaternion Conjugate(HandQuaternion quaternion) {
            return new HandQuaternion(-quaternion.x, -quaternion.y, -quaternion.z, quaternion.w);    
        }
        #endregion

    }
}