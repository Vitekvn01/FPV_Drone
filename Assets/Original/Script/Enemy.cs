using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Destructible))]
public class Enemy : MonoBehaviour
{
    private static List<Enemy> _listEnemies = new List<Enemy>();

    public static List<Enemy> ListEnemies => _listEnemies;

    private Destructible _dest;
    private void Start()
    {
        AddListEnemies();

        _dest = GetComponent<Destructible>();

        _dest.OnDeadEvent.AddListener(RemoveListEnemies);
    }

    private void AddListEnemies()
    {
        _listEnemies.Add(this);
    }

    private void RemoveListEnemies()
    {
        _listEnemies.Remove(this);
    }
}
