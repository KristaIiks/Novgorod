using StudySystem;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class sockets : XRSocketInteractor, IStudy
{
    private bool _enabled = false;

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && _enabled;
    }

    protected override void Awake()
    {
        base.Awake();
        selectEntered.AddListener((s) => Stop());
    }

    public void StartStudy()
    {
        _enabled = true;
    }

    private void Stop()
    {
        this.GetOldestInteractableSelected().transform.GetComponent<XRGrabInteractable>().enabled = false;
    }
}
