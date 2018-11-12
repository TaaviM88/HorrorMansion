using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInteraction : MonoBehaviour {

    public Interactable focus;
    Transform target; // Reference to enemy
    CharacterCombat combat;

    private void Start()
    {
        combat = GetComponent<CharacterCombat>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position + (new Vector3(0, 1, 0)), transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1.5f))
            {

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                    interactable.Interact();
                    Debug.DrawLine(ray.origin, hit.point);
                    target = interactable.transform;
                    
                    //FaceTarget();

                    CharacterStats targetstat = interactable.GetComponent<CharacterStats>();
                    if (targetstat != null)
                    {
                        interactable.Interact();
                        combat.Attack(targetstat);
                        Debug.DrawLine(ray.origin, hit.point);
                        //target = enemy.transform;
                        //FaceTarget();
                    }
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.DeFocused();

            focus = newFocus;
        }
        
        newFocus.Onfocused(transform);
    }


    //Keksi miten päästää tästä tilanteessa pois
    void RemoveFocus()
    {
        if(focus != null)
            focus.DeFocused();

        focus = null;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position.normalized);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
