using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{
    BlocksManager bm;
    [SerializeField] GameObject blockSparkleVFX;


    private void Start()
    {
        bm = GetComponentInParent<BlocksManager>();
    }
    [SerializeField] public int pointsValue = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();
        ball.BlockDestroied();//trocar por AudioSource play sound
        BlockDestroy();
    }

    private void TriggerParticlesVFX()
    {
        GameObject sparkle = Instantiate(blockSparkleVFX, bm.transform);
        sparkle.transform.position = transform.position;
        Destroy(sparkle, 2000f);
    }

    private void BlockDestroy()
    {

        TriggerParticlesVFX();
        bm.BlockDestroy(pointsValue);
        Destroy(gameObject);
    }
}
