using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectObj : MonoBehaviour
{
    [SerializeField] private string selectTag = "Select";
    [SerializeField] private Material solidMaterial;

    private Material defMaterial;
    private GameObject clicked = null;
    private GameObject prevClicked= null;
    private Renderer selectRend;
    private Renderer prevRend;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 400f))
            {
                clicked = hit.transform.gameObject;
                
                if(clicked.CompareTag(selectTag))
                {
                    if (clicked != prevClicked)
                    {
                        if(prevClicked !=null)
                        {
                            prevRend = prevClicked.GetComponent<Renderer>();
                            prevRend.material = defMaterial;
                        }

                        selectRend = clicked.GetComponent<Renderer>();
                        defMaterial = selectRend.material;
                        selectRend.material=solidMaterial;

                        prevClicked = clicked;
        
                    }
                }
            }
        }
    }
}
