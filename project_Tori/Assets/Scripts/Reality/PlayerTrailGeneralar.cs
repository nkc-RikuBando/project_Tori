using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailGeneralar : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Rigidbody rb;
    private TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = _player.GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y >= 0f)
        {
            ActiveFlg(false);
        }
        else
        {
            ActiveFlg(true);
        }
    }

    private void ActiveFlg(bool flg)
    {
        trailRenderer.enabled = flg;
    }
}
