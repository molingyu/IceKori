using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Plugins.IceKori.Demo.Script
{
     public class GalgameDemoScene : MonoBehaviour
     {
         public MessageWindow MessageWindow;
         public Image Background;

         void Start()
         {
             Gvar.MessageWindow = MessageWindow;
             Gvar.Background = Background;
         }

         void Update()
         {
             if (Input.GetKeyDown(KeyCode.Escape) && !MessageWindow.gameObject.activeSelf)
             {
                 MessageWindow.gameObject.SetActive(true);
             }
         }
    }
}
