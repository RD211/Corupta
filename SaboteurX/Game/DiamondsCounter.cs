using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaboteurX.Game
{
    public partial class DiamondsCounter : UserControl
    {
        private int current=10, needed=10;
        public DiamondsCounter(int current, int needed)
        {
            InitializeComponent();
            SetCurrent(current);
            SetNeeded(needed);
            
        }
        public DiamondsCounter()
        {
            InitializeComponent();
        }
        public void SetCurrent(int current)
        {
            this.current = current;
            UpdateLabel();
        }
        public void SetNeeded(int needed)
        {
            this.needed = needed;
            UpdateLabel();
        }
        private void UpdateLabel()
        {
            this.lbl_counter.Text = $"{current}/{needed}";
        }
    }
}
