using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTranslater : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] 
    private float distance = 5.0f;
    [SerializeField]
    private float moveSpeed = 2.0f;
    private Vector3 mainCamPos;
    private Vector3 otherGOPos;
    public GameObject otherGO;
    [SerializeField] private bool isActive = false;
    [SerializeField] private float alphaDiminishMultiplier = 5.0f;
    private CanvasGroup canvasAlpha;
    private void Awake()
    {
        mainCam = Camera.main;
        otherGO.SetActive(false);
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PostProcessing"))
        {
            otherGO.SetActive(true);
            isActive = true;
            canvasAlpha = otherGO.GetComponent<CanvasGroup>();
            
        }

    }

 
    
    private void Update()
    {
        if (isActive) 
        {
            mainCamPos = mainCam.transform.position;
            otherGOPos = otherGO.transform.localPosition;
            
           
            if (Vector3.Distance(mainCamPos, otherGOPos) >= distance)
            {

                Move();
                Debug.Log(Vector3.Distance(mainCamPos, otherGOPos));
                Vector3 relativePos = mainCamPos - otherGOPos;
                Quaternion lookRotation = Quaternion.LookRotation(-relativePos);
                otherGO.transform.rotation = lookRotation;
            }

            else
            {
                canvasAlpha.alpha = Mathf.Lerp(canvasAlpha.alpha, 0, moveSpeed * Time.deltaTime * alphaDiminishMultiplier);

                if (canvasAlpha.alpha <= 0.2f)
                {
                    isActive = false;
                    otherGO.SetActive(false);
                    gameObject.GetComponent<SimpleTranslater>().enabled = false;
                }

            }
            
        }
    
      
    }
    
    private void Move()
    {
        otherGO.transform.localPosition = Vector3.Lerp(otherGO.transform.localPosition, mainCamPos, moveSpeed * Time.deltaTime);
    }

   
}
