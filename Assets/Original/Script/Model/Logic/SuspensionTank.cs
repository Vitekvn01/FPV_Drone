using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspensionTank : MonoBehaviour
{
    [SerializeField] private Vector3 axisRollers;
    [SerializeField] private Transform[] _rollers;
    [SerializeField] private GameObject[] _tracks;
    [SerializeField] private bool _dirRotate;
    private Material[] _materials;
    float trackYOffsetPos = 0f;
    private float dir;
    private void Start()
    {
        _materials = new Material[_tracks.Length];
        for (int i = 0; i < _tracks.Length; i++)
        {
            _materials[i] = _tracks[i].GetComponent<Renderer>().material;
        }

        if (_dirRotate)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
    }
    public void RollerRotate(float speed)
    {
        if (_rollers != null)
        {
            foreach (Transform roller in _rollers)
            {

                    roller.Rotate(axisRollers, speed * 100 * dir, Space.Self);

            }
        }

    }

    public void TrackScrolling(float speed)
    {
        if (_tracks != null)
        {
            foreach (Material track in _materials)
            {
                trackYOffsetPos = (trackYOffsetPos + speed) % 1;
                track.mainTextureOffset = new Vector2(0, trackYOffsetPos);
            }
        }

    }
}
