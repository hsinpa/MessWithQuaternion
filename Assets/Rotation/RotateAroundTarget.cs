using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
    [SerializeField]
    private Transform target_object;

    public Vector3 rotate_direction;

    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = rotate_around_target(this.transform.position, target_object.position);
    }

    Vector3 rotate_vector_by_quaternion(Vector3 r, Quaternion q){
        Quaternion q_v =  new Quaternion(x: r.x, y: r.y, z:r.z, w: 0);

        Quaternion q_conj = Quaternion.Inverse(q.normalized);
        Quaternion q_multiply = q * q_v * q_conj;
        
        return new Vector3(q_multiply.x, q_multiply.y, q_multiply.z);
    }

    Vector3 rotate_around_target(Vector3 self_pos, Vector3 target_pos) {
        Quaternion quat_x = Quaternion.AngleAxis(rotate_direction.x * Time.deltaTime * speed, Vector3.right);
        Quaternion quat_y = Quaternion.AngleAxis(rotate_direction.y * Time.deltaTime * speed, Vector3.up);
        Quaternion quat_z = Quaternion.AngleAxis(rotate_direction.z * Time.deltaTime * speed, Vector3.forward);

        Quaternion quat_merge = (quat_x * quat_y * quat_z).normalized;

        // Calculate the relative position vector
        Vector3 r = self_pos - target_pos;

        Vector3 r_prime = rotate_vector_by_quaternion(r, quat_merge);

        return r_prime + target_pos;
    }
}
