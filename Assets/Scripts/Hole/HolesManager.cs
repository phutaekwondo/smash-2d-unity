using System;
using System.Collections.Generic;
using UnityEngine;

public class HolesManager : MonoBehaviour
{
    [SerializeField] private List<Hole> m_holes = new List<Hole>();

    internal Hole GetRandomEmptyHole()
    {
        //get list of empty holes
        List<Hole> emptyHoles = new List<Hole>();
        foreach (Hole hole in m_holes)
        {
            if (hole.IsEmpty())
            {
                emptyHoles.Add(hole);
            }
        }

        //get a random empty hole
        int randomIndex = UnityEngine.Random.Range(0, emptyHoles.Count);
        Hole randomEmptyHole = emptyHoles[randomIndex];
        return randomEmptyHole;
    }
}

