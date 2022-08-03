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
    [SerializeField] private GameObject textSphere;
    [SerializeField] private GameObject textCube;

    public GameObject Sphere;
    public GameObject Cube;
    private Vector3 defPosSphere;
    private Vector3 defPosCube;
    private Vector3 newPosSphere;
    private Vector3 newPosCube;
    void Start()
    {
        defPosSphere=Sphere.transform.position;
        Vector3 newPosSphere=defPosSphere;
        defPosCube=Cube.transform.position;
        Vector3 newPosCube=defPosCube;
    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 300f))
            {
                clicked = hit.transform.gameObject;
                
                if(clicked.CompareTag(selectTag))
                {

                    if (hit.collider.name =="Sphere")
                    {
                        textSphere.SetActive(true);
                        textCube.SetActive(false);

                        defPosSphere= Sphere.transform.position;
                        Vector3 newPosSphere= defPosSphere;
                        newPosSphere.y = +1.5f;
                        Sphere.transform.position=newPosSphere;

                        Cube.transform.position=defPosCube;
                    }

                    else if(hit.collider.name=="Cube")
                    {
                        textCube.SetActive(true);
                        textSphere.SetActive(false);

                        defPosCube = Cube.transform.position;
                        Vector3 newPosCube=defPosCube;
                        newPosCube.y = +1.5f;
                        Cube.transform.position= newPosCube;

                        Sphere.transform.position= defPosSphere;
                    }
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
