using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI Text;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                Text.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        Text.gameObject.SetActive(true);
        Text.text = curInteractable.GetInteractPrompt();
    }

    public void OnTriggerEnter(Collider on)
    {
        if(on.CompareTag("Interactable"))
        {
            Debug.Log("ºÎµúÄ§");
            curInteractable = on.GetComponent<IInteractable>();
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
            Text.gameObject.SetActive(false);
        }
    }
}