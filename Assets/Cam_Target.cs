using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class CamTarget : MonoBehaviour

{

    public Transform target;
    public float distance;
    public float height;
    public float rotationDamping;
    public float heightDamping;

    float targetRotationAngle;
    float targetHeight;
    float currentRotationAngle;
    float currentHeight;

    private Quaternion currentRotation;


    void LateUpdate()

    {

        if (target != null)

        {

            //Calcul de la rotation et hauteur cible.

            targetRotationAngle = target.eulerAngles.y;
            targetHeight = target.position.y + height;



            currentRotationAngle = transform.eulerAngles.y;
            currentHeight = transform.position.y;



            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, rotationDamping * Time.deltaTime);

            currentHeight = Mathf.Lerp(currentHeight, targetHeight, heightDamping * Time.deltaTime);

            currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);



            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;



            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
            transform.LookAt(target);



        }

    }

}