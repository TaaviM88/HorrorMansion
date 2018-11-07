using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = 3f;
    public Transform interactionTransform;
    bool isfocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if(isfocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void Onfocused(Transform playertransform)
    {
        isfocus = true;
        player = playertransform;
        hasInteracted = false;
    }
    public void DeFocused()
    {
        isfocus = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
