using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
public static class Cache
{
    public static Dictionary<Collider, Renderer> cacheMaterialCollision = new Dictionary<Collider, Renderer>();

    public static Renderer GetRendererComponentForCollider(Collider collider)
    {
        if (!cacheMaterialCollision.ContainsKey(collider))
        {
            Renderer collisMaterial = collider.gameObject.GetComponent<Renderer>();

            cacheMaterialCollision[collider] = collisMaterial;
        }

        return cacheMaterialCollision[collider];
    }
}
