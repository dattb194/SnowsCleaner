using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MyRay 
{
    private Vector3 direc {
        get
        {
            switch (typeRay)
            {
                case TypeRay.top:
                    return transform.forward;
                case TypeRay.bot:
                    return -transform.forward;
                case TypeRay.right:
                    return transform.right;
                case TypeRay.left:
                    return -transform.right;
                    default: return Vector3.zero;
            }
        }

    }

    [SerializeField]
    private float dis = 0.5f;

    [SerializeField]
    private LayerMask m_mask;

    [SerializeField]
    private TypeRay typeRay;
    public TypeRay _TypeRay { get => typeRay; }

    [SerializeField]
    private Transform transform;

    RaycastHit[] hits = new RaycastHit[2];
    Ray[] rays = new Ray[2];

    Vector3[] v = new Vector3[2];
    Vector3 pos { get => transform.position; }
   
    public Vector3 GetTarget()
    {
        RaycastHit m_hit;

        Ray m_ray = new Ray(transform.position, direc);

        if (Physics.Raycast(m_ray, out m_hit, 100, m_mask))
        {
            if (m_hit.collider != null)
            {
                if (m_hit.collider.gameObject.tag == "wall")
                {
                    switch (typeRay)
                    {
                        case TypeRay.top:
                            return new Vector3(transform.position.x, transform.position.y, m_hit.collider.gameObject.transform.position.z - 1);
                        case TypeRay.bot:
                            return new Vector3(transform.position.x, transform.position.y, m_hit.collider.gameObject.transform.position.z + 1);
                        case TypeRay.right:
                            return new Vector3(m_hit.collider.gameObject.transform.position.x - 1, transform.position.y, transform.position.z);
                        case TypeRay.left:
                            return new Vector3(m_hit.collider.gameObject.transform.position.x + 1, transform.position.y, transform.position.z);
                    }
                }
            }
        }

        return Vector3.zero;
    }
    public bool CheckHit()
    {
        switch (typeRay)
        {
            case TypeRay.top:
                v[0] = new Vector3(pos.x + .49f, pos.y, pos.z);
                v[1] = new Vector3(pos.x - .49f, pos.y, pos.z);
                break;

            case TypeRay.bot:
                v[0] = new Vector3(pos.x + .49f, pos.y, pos.z);
                v[1] = new Vector3(pos.x - .49f, pos.y, pos.z);
                break;

            case TypeRay.right:
                v[0] = new Vector3(pos.x, pos.y, pos.z + .49f);
                v[1] = new Vector3(pos.x, pos.y, pos.z - .49f);
                break;

            case TypeRay.left:
                v[0] = new Vector3(pos.x, pos.y, pos.z + .49f);
                v[1] = new Vector3(pos.x, pos.y, pos.z - .49f);
                break;

            default: break;
        }

        rays[0] = new Ray(v[0], direc);
        rays[1] = new Ray(v[1], direc);

        int _i = 0;
        for (int i = 0; i < 2; i++)
        {
            if (Physics.Raycast(rays[i], out hits[i], dis, m_mask))
            {
                if (hits[i].collider != null)
                {
                    if (hits[i].collider.gameObject.tag == "wall")
                        _i++;
                }
            }
        }
        return _i > 0;
    }

}
[Serializable]
public enum TypeRay { top, bot, left, right }