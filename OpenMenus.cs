using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenMenus : MonoBehaviour
{
  

    [System.Serializable]
    public class MenuKeyMapping
    {
        public GameObject menuItem;  // The UI element to toggle
        public KeyCode keyPressUsed;  // The key used to toggle this UI element
    }

    public List<MenuKeyMapping> menuKeyMappings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        foreach (MenuKeyMapping mapping in menuKeyMappings)
        {
            if (Input.GetKeyDown(mapping.keyPressUsed))
            {
                mapping.menuItem.SetActive(!mapping.menuItem.activeSelf);
            }
        }
    }

   
    
}
