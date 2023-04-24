using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EquipController : MonoBehaviour
{
    [SerializeField] private EquipItem curEquipItem;
    [SerializeField] private GameObject curEquipObject;

    [SerializeField] private bool useInput;

    [SerializeField] private ItemData testEquipItem;

    [Header("Components")]
    [SerializeField] private Transform equipObjectOrigin;
    [SerializeField] private MouseUtilities mouseUtilities;

    void Start ()
    {
        Equip(testEquipItem);
    }

    void Update ()
    {
        Vector2 mouseDir = mouseUtilities.GetMouseDirection(transform.position);

        transform.up = mouseDir;

        if(HasItemEquipped())
        {
            if(useInput && EventSystem.current.IsPointerOverGameObject() == false)
            {
                curEquipItem.OnUse();
            }
        }
    }

    public void Equip (ItemData item)
    {
        if(HasItemEquipped())
            UnEquip();

        curEquipObject = Instantiate(item.EquipPrefab, equipObjectOrigin);
        curEquipItem = curEquipObject.GetComponent<EquipItem>();
    }

    public void UnEquip ()
    {
        if (curEquipObject != null)
            Destroy(curEquipObject);

        curEquipItem = null;
    }

    public bool HasItemEquipped ()
    {
        return curEquipItem != null;
    }


    //Lesson 22 3:47
    public void OnUseInput (InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
            useInput = true;
        Debug.Log("Item Used");
        if (context.phase == InputActionPhase.Canceled)
            useInput = false;
    }
}