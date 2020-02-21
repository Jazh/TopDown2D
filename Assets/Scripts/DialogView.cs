using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TopDown {
    public class DialogView : MonoBehaviour
    {

        private DialogModel _model;
        // Start is called before the first frame update
        public void Init(DialogModel model)
        {
            _model = model;
        }


        public void Show() {
            _model.dialog.gameObject.SetActive(true);
        }

        public void Hide() {
            _model.dialog.gameObject.SetActive(false);
        }

        public void ShowText(string text) {
            _model.dialog.Find("Text").GetComponent<Text>().text = text;
        }

        public void ShowFace(Sprite face)
        {
            _model.dialog.Find("Face-box/Face")
                .GetComponent<Image>()
                .sprite = face;
        }

        public void ShowArrow(bool finish)
        {
            _model.dialog.Find("Arrow").
                gameObject.SetActive(!finish);
        }
    }
}