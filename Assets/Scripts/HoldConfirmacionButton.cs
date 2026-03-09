using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldConfirmacionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image fillImage; //imagen a rellenar
    public float holdTime; // segundos que se tiene que presionar
    public GameObject targetObject; //objeto en la escena

    private float holdTimer = 0f; //contador del tiempo mantenido
    private bool isHolding = false; //si se esta presionando

    void Update()
    {

        if (!isHolding) return;

        holdTimer += Time.deltaTime;
        float progress = Mathf.Clamp01(holdTimer / holdTime);

        if (fillImage != null)
        {
            fillImage.fillAmount = progress; //relleno la barra con el progreso
        }
            

        if (progress >= 1f) //si el progreso es mas grande o igual a 1
        {
            isHolding = false; //para de contar
            holdTimer = 0f;//resetea el timer
            fillImage.fillAmount = 0f; //Resetea la barra a 0

            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf); //esto alterna: si esta activo lo desactiva y a viceversa
            }
                
        }
    }
    public void OnPointerDown(PointerEventData eventData) //presionando el boton
    {
        isHolding = true; //empiezo a contar
        holdTimer = 0f; //reinicio el contador
    }

    public void OnPointerUp(PointerEventData eventData) //soltando el boton
    {
        isHolding = false; //Para de contar
        holdTimer = 0f; //Resetea el contador
        if (fillImage != null)
        {
            fillImage.fillAmount = 0f; //vacia la barra
        }
            
    }

    

    
}
