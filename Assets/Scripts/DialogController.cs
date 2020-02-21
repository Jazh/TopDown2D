using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown {
    public class DialogController : MonoBehaviour
    {
        static public DialogController instance;

        static public void Show(int index)
        {
            instance.ShowDialog();
            instance.LoadDialog(index);
        }

        static public void Hide()
        {
            instance.HideDialog();
        }

        static public void Next()
        {
            instance.Next(instance.nextDialogId);
        }

        private DialogModel model;
        private DialogView view;

        [SerializeField]
        private int nextDialogId = -1;

        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
            model = GetComponent<DialogModel>();
            view = GetComponent<DialogView>();
        }

        void Start()
        {
            view.Init(model);
            HideDialog();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) {
                HideDialog();                
            }
        }

        // Update is called once per frame
        public void ShowDialog()
        {
            view.Show();
            
        }
        public void HideDialog() {
            view.Hide();
        }

        private void LoadDialog(int index) {
            //DialogModel.Dialog dialog = model.dialogs[index];
            //view.ShowText(model.textList[dialog.text]);
            //model.GetTextByDialogId(index);
            view.ShowText(model.GetTextByDialogId(index));
            view.ShowFace(model.GetFaceByDialogId(index));
            view.ShowArrow(model.IsEndById(index));
        }
        private void Next(int index)
        {
            if (index >= 0)
                LoadDialog(index);
            else
                HideDialog();
        }

    }
}