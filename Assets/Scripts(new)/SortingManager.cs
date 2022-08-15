using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    public SortingScript[] sortingScripts;

    private SpriteRenderer Sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sortingScripts = FindObjectsOfType<SortingScript>();

        for (int i = 0; i < sortingScripts.Length; i++)
        {
            for(int c = 0; c < sortingScripts.Length; c++)
            {
                if (c != i)
                {
                    if (sortingScripts[i].gameObject.transform.position.y + sortingScripts[i].YOffset
                        < sortingScripts[c].gameObject.transform.position.y + sortingScripts[c].YOffset)
                    {
                        sortingScripts[i].Renderer.sortingOrder = 1;
                        sortingScripts[c].Renderer.sortingOrder = 0;
                    }
                    else
                    {
                        sortingScripts[c].Renderer.sortingOrder = 1;
                        sortingScripts[i].Renderer.sortingOrder = 0;
                    }
                }
            }
        }
    }
}
