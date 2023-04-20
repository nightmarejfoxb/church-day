using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EquipController : MonoBehaviour
{
    private Equip curEquipItem;
    private GameObject curEquipObject;

    private bool useInput;

    [Header("Components")]
    [SerializeField] private Transform equipObjectOrigin;
    

    void Update()
    {
       

        if (HasItemEquipped())
        {
            if (useInput && EventSystem.current.IsPointerOverGameObject() == false)
            {
                curEquipItem.OnUse();
            }
        }
    }

    

    public void UnEquip()
    {
        if (curEquipObject != null)
            Destroy(curEquipObject);

        curEquipItem = null;
    }

    public bool HasItemEquipped()
    {
        return curEquipItem != null;
    }

    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            useInput = true;
        if (context.phase == InputActionPhase.Canceled)
            useInput = false;
    }
}
