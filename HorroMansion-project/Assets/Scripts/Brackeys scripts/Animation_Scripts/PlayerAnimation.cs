using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : CharacterAnimator {
    public WeaponAnimations[] weaponAnimations;
    Dictionary<Equipment, AnimationClip[]> weaponAnimationDict;
    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmenChanged += OnEquipmentChanged;
        weaponAnimationDict = new Dictionary<Equipment, AnimationClip[]>();
        foreach(WeaponAnimations a in weaponAnimations)
        {
            weaponAnimationDict.Add(a.weapon, a.clips);
        }
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem !=null && newItem.equipSlot == EquipmentSlot.Weapon )
        {
            animator.SetLayerWeight(1, 1);
            if(weaponAnimationDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAnimationDict[newItem];
            }

        }
        else if(newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(0, 0);
            currentAttackAnimSet = defaultAttackAnimationSet;
        }
        
    }
    [System.Serializable]
    public struct WeaponAnimations
    {
        public Equipment weapon;
        public AnimationClip[] clips; 
    }
}
