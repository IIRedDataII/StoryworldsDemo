using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datapad : Interactable
{
    //Prefab
    [SerializeField] private GameObject datapadImage;
    //Instance of the Prefab
    private GameObject  _currView;
    protected override void SpecificAction()
    {
        _currView = Instantiate(datapadImage);
        _currView.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
    }

    protected override void UndoSpecificAction()
    {
        Destroy(_currView);
    }
    
    private void Update()
    {
        if (Active && (Input.GetButtonDown("UndoInteract") || Input.GetMouseButtonDown(0)))
        {
            UndoAction();
        }
    }
}
