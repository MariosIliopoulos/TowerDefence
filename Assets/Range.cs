using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{

    private Node target;
    public GameObject cylinder;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            transform.localScale = new Vector3(target.turretBlueprint.range * 2, .5f, target.turretBlueprint.range * 2);
        }
        else
        {
            transform.localScale = new Vector3(target.turretBlueprint.upgradedRange * 2, .5f, target.turretBlueprint.upgradedRange * 2);
        }
        cylinder.SetActive(true);
    }

    public void Hide()
    {
        cylinder.SetActive(false);
    }

}
