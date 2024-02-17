using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float rayDistance = 1f;
    public Color rayColor = Color.red;
    public float moveSpeed = 4f;
    public float rotationSpeed = 0.2f;

void Update()
{

    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    Ray centerRay = new Ray(transform.position, transform.forward);
    Ray rightRay = new Ray(transform.position + transform.right * 0.5f, transform.forward);
    Ray leftRay = new Ray(transform.position - transform.right * 0.5f, transform.forward);

    RaycastHit centerHit, rightHit, leftHit;
    if (Physics.Raycast(centerRay, out centerHit, rayDistance))
    {

        Debug.Log("Center Hit: " + centerHit.collider.gameObject.name);
    }
    if (Physics.Raycast(rightRay, out rightHit, rayDistance))
    {

        Debug.Log("Right Hit: " + rightHit.collider.gameObject.name);
        RotateLeft();
    }
    if (Physics.Raycast(leftRay, out leftHit, rayDistance))
    {
        Debug.Log("Left Hit: " + leftHit.collider.gameObject.name);
        RotateRight();
    }
}

void OnDrawGizmos()
{

    DrawRay(transform.position, transform.forward * rayDistance, rayColor); // Center ray
    DrawRay(transform.position + transform.right * 0.5f, transform.forward * rayDistance, rayColor); // Right ray
    DrawRay(transform.position - transform.right * 0.5f, transform.forward * rayDistance, rayColor); // Left ray
}

void DrawRay(Vector3 origin, Vector3 direction, Color color)
{
    Gizmos.color = color;
    Gizmos.DrawRay(origin, direction);
}

void RotateRight()
{
    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
}

void RotateLeft()
{
    transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
}

}
