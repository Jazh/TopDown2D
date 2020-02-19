using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown { 
public class DialogModel : MonoBehaviour
{
        public List<string> textList = new List<string>() { 
        "",
        "",
        ""
        };

        public List<Sprite> facesList;

        [System.Serializable]
        public struct Dialog {
            public int text;
            public int face;
            public int next;
        }

        public Dialog[] dialogs;

        public RectTransform dialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

        public string GetTextByDialogId(int id) {
            return GetTextByDialog(dialogs[id]);
        }

        public string GetTextByDialog(Dialog d) {
            return textList[d.text];
        
        }

        public string GetFaceByDialogId(int id)
        {
            return GetFaceByDialog(dialogs[id]);
        }

        public string GetFaceByDialog(Dialog d)
        {
            return facesList[d.text];

        }

    }

}