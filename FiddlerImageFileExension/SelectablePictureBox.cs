using System;
using System.Windows.Forms;

namespace FiddlerImageFileExension
{
    public partial class SelectablePictureBox : PictureBox
    {
        private bool selected;
        public bool Selected
        {
            get { return this.selected; }
            set
            {
                this.selected = value;
                this.Invalidate();
                this.SelectedChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler SelectedChanged;

        public event EventHandler SelectedAll;

        public event EventHandler Deleted;

        private Action saveAction;
        public Action SaveAction
        {
            get { return this.saveAction; }
            set { this.saveAction = value; }
        }

        public SelectablePictureBox()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();

            if (e.Button == MouseButtons.Left)
            {
                this.Selected = !this.Selected;
            }

            base.OnMouseDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {            
            if (e.KeyData == Keys.Delete)
            {
                this.Deleted?.Invoke(this, new EventArgs());
            }
            if (e.KeyData == Keys.Space)
            {
                this.Selected = !this.Selected;
            }
            if (e.Shift && e.KeyData == Keys.A)
            {
                this.SelectedAll?.Invoke(this, new EventArgs());
            }
            base.OnKeyUp(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.Invalidate();
            base.OnLeave(e);
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Focused)
            {
                var controlRectangle = this.ClientRectangle;
                controlRectangle.Inflate(0, 0);
                ControlPaint.DrawFocusRectangle(pe.Graphics, controlRectangle);
            }

            if (this.Selected)
            {
                var inside = this.ClientRectangle;
                inside.Inflate(-1, -1);

                ControlPaint.DrawBorder(pe.Graphics, inside, System.Drawing.Color.LightGreen, ButtonBorderStyle.Solid);
            }
        }

    }
}
