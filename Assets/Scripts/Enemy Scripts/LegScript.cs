using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpperLeftLegScript : MonoBehaviour
{
    EnemyScript enemyScript;
    string[] game_object_name = { "LeftUpperLeg", "RightUpperLeg"};
    private void Start()
    {
        enemyScript = transform.parent.GetComponent<EnemyScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && enemyScript.last_collided_with_arrow != collision.gameObject)
        {
            enemyScript.PlaySound();
            enemyScript.last_collided_with_arrow = collision.gameObject;
            ArrowScript arrow_script = collision.gameObject.GetComponent<ArrowScript>();
            if (arrow_script.is_active)
            {
                if (!enemyScript.is_dead)
                {
                    enemyScript.Mark_Dead();
                    enemyScript.PlaySound();
                }
                int indx = Array.IndexOf(game_object_name, gameObject.name);
                if (indx != -1)
                    enemyScript.splatter(indx + 3);
                else { }
                HingeJoint2D joint = GetComponent<HingeJoint2D>();
                joint.enabled = false;
                EnemyScript parent_script = gameObject.GetComponentInParent<EnemyScript>();
            }
        }
    }
}
