using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.XR;

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
        try //����ó����
        {
            camera = Camera.main;
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e.ToString());
        }
    }

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

    private void SetPromptText() //������ ���� ��¿�
    {
        Text.gameObject.SetActive(true);
        Text.text = curInteractable.GetInteractPrompt();
    }

    public void OnTriggerEnter(Collider on) //�����۰� �ε�ĥ ��� ������ ȿ�� �ߵ�
    {
        if(on.CompareTag("Interactable"))
        {
            Debug.Log("�ε�ħ");
            curInteractable = on.GetComponent<IInteractable>();
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
            Text.gameObject.SetActive(false);
        }
    }
}