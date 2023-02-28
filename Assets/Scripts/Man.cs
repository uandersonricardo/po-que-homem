using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    public string type;
    public GameObject model;
    [SerializeField] public LovemeterParameters lovemeterParameters;
    [SerializeField] public List<Dialogue> dialogues;
    public string notInterestedText;
    public ItemType itemToGive;
    public string itemToGiveText;
    public string thankText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
