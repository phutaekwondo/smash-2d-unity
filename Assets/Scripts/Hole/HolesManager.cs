using System.Collections.Generic;
using UnityEngine;

public class HolesManager : MonoBehaviour
{
    [SerializeField] private List<Hole> m_holes = new List<Hole>();

#nullable enable
    public Hole? GetRandomEmptyHole()
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

        if (emptyHoles.Count == 0)
        {
            return null;
        }

        //get a random empty hole
        int randomIndex = UnityEngine.Random.Range(0, emptyHoles.Count);
        Hole randomEmptyHole = emptyHoles[randomIndex];
        return randomEmptyHole;
    }

    public List<Hole>? GetMultiEmptyHoles(int count)
    {
        if (GetEmptyHolesCount() < count)
        {
            return null;
        }

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
        List<Hole> randomEmptyHoles = new List<Hole>();
        for (int i = 0; i < count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, emptyHoles.Count);
            Hole randomEmptyHole = emptyHoles[randomIndex];
            randomEmptyHoles.Add(randomEmptyHole);
            emptyHoles.RemoveAt(randomIndex);
        }
        return randomEmptyHoles;
    }
#nullable disable 

    public int GetEmptyHolesCount()
    {
        int count = 0;
        foreach (Hole hole in m_holes)
        {
            if (hole.IsEmpty())
            {
                count++;
            }
        }
        return count;
    }
}

