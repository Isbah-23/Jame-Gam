using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperRightArmScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            HingeJoint2D joint = GetComponent<HingeJoint2D>();
            joint.enabled = false;
            EnemyScript parent_script = gameObject.GetComponentInParent<EnemyScript>();
            parent_script.Make_Bleed("l");
        }
    }
}
